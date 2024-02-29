using UnityEngine;

public class SlimeGroundEnemyMovement : MonoBehaviour
{
    [SerializeField]
    private float _movementSpeed;
    private float _movementDirection;

    private GroundEnemyCollision _groundEnemyCollision;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _groundEnemyCollision = GetComponent<GroundEnemyCollision>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        // When enemy is created, by default, start moving right
        _movementDirection = _movementSpeed;
        _rigidBody.velocity = new Vector2(_movementDirection, _rigidBody.velocity.y);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckChangeDirection();
        _rigidBody.velocity = new Vector2(_movementDirection, _rigidBody.velocity.y);
    }

    private void CheckChangeDirection()
    {
        if(_groundEnemyCollision.FallingRight)
        {
            _movementDirection = -_movementSpeed;
        }
        else if(_groundEnemyCollision.FallingLeft)
        {
            _movementDirection = _movementSpeed;
        }
    }
}
