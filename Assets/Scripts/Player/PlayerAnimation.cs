using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerCollision _playerCollision;
    private PlayerInput _playerInput;
    private Animator _animator;

    private void Awake()
    {
        _playerCollision = GetComponent<PlayerCollision>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 direction = _playerInput.GetDirection();
        SendAnimationStateData(direction);
        FlipAnimation(direction);
    }

    private void SendAnimationStateData(Vector3 direction)
    {
        _animator.SetBool("isGrounded", _playerCollision.IsInGround);
        _animator.SetBool("isMoving", direction.x != 0);
    }

    private void FlipAnimation(Vector3 direction)
    {
        Vector3 scale = transform.localScale;

        if (direction.x < 0)
        {
            scale.x = Mathf.Abs(scale.x) * -1;
        }
        else if (direction.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}
