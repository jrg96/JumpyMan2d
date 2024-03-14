using UnityEngine;

[RequireComponent(typeof(GroundEnemyMovement), typeof(SlimeGroundEnemyAnimation))]
public class SlimeGroundEnemy : MonoBehaviour
{
    [SerializeField]
    private float _horizontalKnockbackForce;
    [SerializeField]
    private float _verticalKnockbackForce;
    [SerializeField]
    private int _scoreToGain;
    [SerializeField]
    private int _livesToRemove;

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
            // Calculate direction the player hit the slime
            Vector2 direction;
            Vector3 collisionDirection = transform.InverseTransformPoint(collision.transform.transform.position);

            if (collisionDirection.x > 0f)
            {
                direction = Vector2.right + Vector2.up;
            }
            else
            {
                direction = Vector2.left + Vector2.up;
            }

            player.OnHit(_livesToRemove, direction * new Vector2(_horizontalKnockbackForce, _verticalKnockbackForce), true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if collision is from player
        Player player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Vector2 knockback = new Vector2(0, _verticalKnockbackForce);
            IMoveableEntity moveableEntity = collision.gameObject.GetComponent<IMoveableEntity>();
            moveableEntity.ApplyKnockbackForce(knockback, 0.2f, true);

            // Add score and destroy slime object
            Game.Instance.AddScore(_scoreToGain);
            Destroy(gameObject);
        }
    }
}
