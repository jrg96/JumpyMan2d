using UnityEngine;

[RequireComponent(typeof(GroundEnemyMovement))]
public class SlimeGroundEnemy : MonoBehaviour
{
    [SerializeField]
    private float _horizontalKnockbackForce;
    [SerializeField]
    private float _verticalKnockbackForce;
    [SerializeField]
    private int _scoreToGain;

    private GroundEnemyMovement _slimeGroundEnemyMovement;

    private void Awake()
    {
        _slimeGroundEnemyMovement = GetComponent<GroundEnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if collision is from a damageable player
        DamageablePlayer player = collision.gameObject.GetComponent<DamageablePlayer>();

        if (player != null)
        {
            // Calculate knockback and apply damage
            Vector2 direction = Vector2.right + Vector2.up;

            if (_slimeGroundEnemyMovement.MovementDirection < 0)
            {
                direction = Vector2.left + Vector2.up;
            }

            player.OnHit(1, direction * new Vector2(_horizontalKnockbackForce, _verticalKnockbackForce));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if collision is from player
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            // Add score and destroy slime object
            Game.Instance.AddScore(_scoreToGain);
            Destroy(gameObject);
        }
    }
}
