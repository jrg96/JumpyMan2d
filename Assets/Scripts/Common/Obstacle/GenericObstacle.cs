using UnityEngine;

/// <summary>
/// Generic class for basic calculations for obstacles in the platformer
/// 
/// An obstacle can be configured in 2 ways:
///     -> As a Trigger: for objects we want to pass through
///     -> As a Collider: for objects we want to sit into
/// </summary>
public class GenericObstacle : MonoBehaviour
{
    [SerializeField]
    private int _livesToRemove;

    [SerializeField]
    private float _verticalKnockbackForce;
    
    [SerializeField]
    private float _horizontalKnockbackForce;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if object who activated the trigger is a player
        DamageablePlayer player = collision.GetComponent<DamageablePlayer>();
        ApplyDamageLogic(player);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if object who activated the trigger is a player
        DamageablePlayer player = collision.collider.gameObject.GetComponent<DamageablePlayer>(); ;
        ApplyDamageLogic(player);
    }

    private void ApplyDamageLogic(DamageablePlayer player)
    {
        if (player != null)
        {
            // Apply collision with vertical knockback
            Vector2 knockback = new Vector2(_horizontalKnockbackForce, _verticalKnockbackForce);
            player.OnHit(_livesToRemove, knockback, true);
        }
    }
}
