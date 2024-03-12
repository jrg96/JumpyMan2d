using System.Collections;
using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput), typeof(GroundEntityCollision), typeof(PlayerAnimation))]
public class PlayerMovement : MonoBehaviour, IMoveableEntity
{
    /*
     * Movement related properties
     */
    [SerializeField]
    private float _movementSpeed;
    public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }

    [SerializeField]
    private float _jumpForce;
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    public bool InnerMovementActive { get; set; } = true;

    [SerializeField]
    private PlayerInput _playerInput;
    private GroundEntityCollision _groundEntityCollision;
    private Rigidbody2D _rigidBody;

    private Vector3 _currentMovement;


    /*
     * Unity Functions
     */
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _groundEntityCollision = GetComponent<GroundEntityCollision>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _currentMovement = _playerInput.GetDirection();
        JumpHandler();
    }

    private void FixedUpdate()
    {
        if (InnerMovementActive)
        {
            _rigidBody.velocity = new Vector2(_currentMovement.x * MovementSpeed, _rigidBody.velocity.y);
        }
    }

    private void JumpHandler()
    {
        if (_playerInput.IsJumpKeyPressed() && _groundEntityCollision.IsInGround)
        {
            _rigidBody.velocity = Vector2.up * JumpForce;
            //_rigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }

        //if (_rigidBody.velocity.y >= 0)
        //{
        //    _rigidBody.gravityScale = _jumpingGravityScale;
        //}
        //else
        //{
        //    _rigidBody.gravityScale = _fallingGravityScale;
        //}
    }

    public void ApplyKnockbackForce(Vector2 knockback, float delay, bool resetSpeed)
    {
        StartCoroutine(ApplyKnockbackForceRoutine(knockback, delay, resetSpeed));
    }

    public IEnumerator ApplyKnockbackForceRoutine(Vector2 knockback, float delay, bool resetSpeed)
    {
        InnerMovementActive = false;

        if (resetSpeed)
        {
            _rigidBody.velocity = new Vector2(0, 0);
        }

        _rigidBody.AddForce(knockback, ForceMode2D.Impulse);

        yield return new WaitForSeconds(delay);
        InnerMovementActive = true;
    }
}
