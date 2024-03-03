using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : GenericSingleton<Game>
{
    [SerializeField]
    private int _lives;
    public int Lives 
    { 
        get => _lives; 
        private set 
        {
            _lives = value;

            if (_lives > MaxLives)
            {
                _lives = MaxLives;
            }
        } 
    }

    [SerializeField]
    private int _maxLives;
    public int MaxLives { get => _maxLives; private set=> _maxLives = value; }

    public bool GamePaused { get; set; } = false;
    public int Score { get; private set; } = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Custom methods
     */
    public void AddScore(int score)
    {
        Score += score;
    }

    public void AddLives(int lives)
    {
        Lives += lives;
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
