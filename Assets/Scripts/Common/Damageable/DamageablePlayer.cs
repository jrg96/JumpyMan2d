using System.Collections;
using UnityEngine;

public class DamageablePlayer : MonoBehaviour, IDamageable
{
    [SerializeField]
    private int _lives;
    public int Lives
    {
        get => _lives;
        private set
        {
            _lives = value;

            if (_lives > MaxLives)
            {
                _lives = MaxLives;
            }

            if (_lives < 0)
            {
                _lives = 0;
            }
        }
    }

    [SerializeField]
    private int _maxLives;
    public int MaxLives { get => _maxLives; private set => _maxLives = value; }

    [SerializeField]
    private float _immuneTime;
    public bool Immune { get; set; }

    [SerializeField]
    private LayerMask _playerLayerMask;
    private int _playerLayerNumber;

    [SerializeField]
    private LayerMask _enemyLayerMask;
    private int _enemyLayerNumber;

    private Rigidbody2D _rigidBody;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerLayerNumber = (int)Mathf.Log(_playerLayerMask.value, 2);
        _enemyLayerNumber = (int)Mathf.Log(_enemyLayerMask.value, 2);
    }
    public void OnHit(int damage, Vector2 knockback, bool resetSpeed = false)
    {
        if (!Immune)
        {
            IMoveableEntity moveableEntity = GetComponent<IMoveableEntity>();

            Lives -= damage;

            if (resetSpeed)
            {
                _rigidBody.velocity = new Vector2(0, 0);
            }

            StartCoroutine(moveableEntity.ApplyKnockbackForce(knockback, 0.5f));
            StartCoroutine(ImmuneRoutine());
        }
    }

    public void OnHit(int damage)
    {
        if (!Immune)
        {
            Lives -= damage;
            StartCoroutine(ImmuneRoutine());
        }
    }

    public void AddLives(int lives)
    {
        Lives += lives;
    }

    //private IEnumerator ApplyKnockbackForce(Vector2 knockback, float delay)
    //{
    //    IMoveableEntity moveableEntity = GetComponent<IMoveableEntity>();
    //    moveableEntity.InnerMovementActive = false;
    //    _rigidBody.AddForce(knockback, ForceMode2D.Impulse);

    //    yield return new WaitForSeconds(delay);
    //    moveableEntity.InnerMovementActive = true;
    //}

    private IEnumerator ImmuneRoutine()
    {
        Immune = true;
        Physics2D.IgnoreLayerCollision(_playerLayerNumber, _enemyLayerNumber, true);
        Color color = _spriteRenderer.material.color;
        color.a = 0.5f;
        _spriteRenderer.material.color = color;

        yield return new WaitForSeconds(_immuneTime);

        color.a = 1.0f;
        _spriteRenderer.material.color = color;
        Physics2D.IgnoreLayerCollision(_playerLayerNumber, _enemyLayerNumber, false);
        Immune = false;
    }
}
