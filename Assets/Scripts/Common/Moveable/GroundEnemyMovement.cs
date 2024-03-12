using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GroundEntityCollision), typeof(GroundEnemyCollision))]
public class GroundEnemyMovement : MonoBehaviour, IMoveableEntity
{
    [SerializeField]
    private float _movementSpeed;
    public float MovementSpeed { get => _movementSpeed; private set => _movementSpeed = value; }

    private float _movementDirection;
    public float MovementDirection { get => _movementDirection; private set => _movementDirection = value; }
    public bool InnerMovementActive { get; set; } = true;

    private GroundEnemyCollision _groundEnemyCollision;
    private GroundEntityCollision _groundEntityCollision;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _groundEnemyCollision = GetComponent<GroundEnemyCollision>();
        _groundEntityCollision = GetComponent<GroundEntityCollision>();
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
        if (InnerMovementActive)
        {
            CheckChangeDirection();
            _rigidBody.velocity = new Vector2(_movementDirection, _rigidBody.velocity.y);
        }
    }

    private void CheckChangeDirection()
    {
        if(_groundEnemyCollision.FallingRight 
            || _groundEnemyCollision.RightEnemyCollision 
            || _groundEnemyCollision.RightGroundCollision)
        {
            _movementDirection = -_movementSpeed;
        }
        else if(_groundEnemyCollision.FallingLeft
            || _groundEnemyCollision.LeftEnemyCollision
            || _groundEnemyCollision.LeftGroundCollision)
        {
            _movementDirection = _movementSpeed;
        }
    }

    public IEnumerator ApplyKnockbackForce(Vector2 knockback, float delay)
    {
        throw new System.NotImplementedException();
    }
}
