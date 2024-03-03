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
            Game.Instance.AddScore(ScoreToAdd);
            Game.Instance.AddLives(LivesToAdd);

            Debug.Log("Lives: " + Game.Instance.Lives);
            Debug.Log("Score: " + Game.Instance.Score);

            // Destroy itself
            Destroy(gameObject);
        }
    }
}
