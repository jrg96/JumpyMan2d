using UnityEngine;

public class GenericItem : MonoBehaviour
{
    [SerializeField]
    private int _scoreToAdd;
    public int ScoreToAdd { get => _scoreToAdd; private set => _scoreToAdd = value; }

    [SerializeField]
    private int _livesToAdd;
    public int LivesToAdd { get => _livesToAdd; private set => _livesToAdd = value; }

    [SerializeField]
    private string _playerTag;
    public string PlayerTag { get => _playerTag; private set => _playerTag = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if colliding with player
        if (collision.tag == PlayerTag)
        {
            IDamageable damageableEntity = collision.gameObject.GetComponent<IDamageable>();
            Game.Instance.AddScore(ScoreToAdd);
            damageableEntity.AddLives(LivesToAdd);

            Debug.Log("Score: " + Game.Instance.Score);
            Debug.Log("Lives: " + damageableEntity.Lives);

            // Destroy itself
            Destroy(gameObject);
        }
    }
}
