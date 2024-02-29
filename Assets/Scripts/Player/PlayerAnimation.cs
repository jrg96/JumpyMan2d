using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private GroundEntityCollision _groundEntityCollision;
    private PlayerInput _playerInput;
    private Animator _animator;

    private void Awake()
    {
        _groundEntityCollision = GetComponent<GroundEntityCollision>();
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
        _animator.SetBool("isGrounded", _groundEntityCollision.IsInGround);
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
