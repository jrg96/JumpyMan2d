using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenUiManager : MonoBehaviour
{
    public void StartGame()
    {
        Game.Instance.PauseGame(false);
        Game.Instance.LevelToTeleport = "World 1-1";
        SceneManager.LoadScene("World Transition");
    }
}
