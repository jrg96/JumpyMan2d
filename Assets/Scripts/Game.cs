using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : GenericSingleton<Game>
{
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

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
