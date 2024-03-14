using UnityEngine;

public class SlimeGroundEnemyAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject _destroyEffectPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if collision is from a damageable player
        DamageablePlayer player = collision.gameObject.GetComponent<DamageablePlayer>();

        if (player != null)
        {
            Instantiate(_destroyEffectPrefab, transform.position, Quaternion.identity);
        }
    }
}
