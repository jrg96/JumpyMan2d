using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : GenericSingleton<Game>
{
    public bool GamePaused { get; set; } = false;
    public int Score { get; private set; } = 0;
    public string LevelToTeleport { get; set; }

    /*
     * Custom methods
     */
    public void AddScore(int score)
    {
        Game.Instance.Score += score;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        
        // On Game Over, reset all singletons to reset all current states
        Player.Instance.ResetInstance();
        UIManager.Instance.ResetInstance();
        Game.Instance.ResetInstance();

        SceneManager.LoadScene("Splash Screen");
    }

    public void PauseGame(bool pause)
    {
        if (pause)
        {
            Game.Instance.GamePaused = true;
            Time.timeScale = 0;
        }
        else
        {
            Game.Instance.GamePaused = false;
            Time.timeScale = 1;
        }
    }
}
