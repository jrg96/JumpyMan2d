using UnityEngine;
using UnityEngine.Windows;

[RequireComponent(typeof(PlayerInput), typeof(PlayerCollision), typeof(PlayerAnimation))]
public class PlayerMovement : MonoBehaviour
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

    [SerializeField]
    private PlayerInput _playerInput;
    private PlayerCollision _playerCollision;
    private Rigidbody2D _rigidBody;

    private Vector3 _currentMovement;


    /*
     * Unity Functions
     */
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerCollision = GetComponent<PlayerCollision>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _currentMovement = _playerInput.GetDirection();
        JumpHandler();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_currentMovement.x * MovementSpeed, _rigidBody.velocity.y);
    }

    private void JumpHandler()
    {
        if (_playerInput.IsJumpKeyPressed() && _playerCollision.IsInGround)
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
}
