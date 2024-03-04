using UnityEngine;

[RequireComponent(typeof(VerticalProjectileEnemyMovement))]
public class FireballEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if collided object is player
        DamageablePlayer damageablePlayer = collision.GetComponent<DamageablePlayer>();

        if (damageablePlayer != null)
        {
            // apply damage without knockback
            damageablePlayer.OnHit(1);
        }
    }
}
