using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
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
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var input = _playerInput.GetDirection();
        _rigidBody.velocity = new Vector2(input.x * MovementSpeed, input.y);
    }
}
