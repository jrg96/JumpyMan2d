using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GenericObstacle), typeof(TrapAnimation))]
public class Trap : MonoBehaviour
{
    [SerializeField]
    private float _destroyTime;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collision is with a player, and if it is
        // start disappear coroutine
        IDamageablePlayer player = collision.collider.gameObject.GetComponent<IDamageablePlayer>();

        if (player != null)
        {
            StartCoroutine(DisappearTrap());
        }
    }

    private IEnumerator DisappearTrap()
    {
        // make the trap transparent and then destroy the trap
        Color color = _spriteRenderer.material.color;
        color.a = 0.5f;
        _spriteRenderer.material.color = color;

        yield return new WaitForSeconds(_destroyTime);
        Destroy(gameObject);
    }
}
