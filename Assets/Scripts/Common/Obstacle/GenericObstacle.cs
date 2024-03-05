using UnityEngine;

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

        if (player != null)
        {
            // Apply collision with vertical knockback
            Vector2 knockback = new Vector2(_horizontalKnockbackForce, _verticalKnockbackForce);
            player.OnHit(_livesToRemove, knockback, true);
        }
    }
}
