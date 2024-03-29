using UnityEngine;

public class TrapAnimation : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if player is colliding with the trap
        IDamageablePlayer player = collision.collider.gameObject.GetComponent<IDamageablePlayer>();

        if (player != null)
        {
            _animator.SetBool("trapTouched", true);
        }
    }
}
