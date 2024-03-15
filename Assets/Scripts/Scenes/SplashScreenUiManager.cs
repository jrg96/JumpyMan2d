using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenUiManager : MonoBehaviour
{
    public void StartGame()
    {
        Game.Instance.PauseGame(false);
        SceneManager.LoadScene("World 1-1");
    }
}
