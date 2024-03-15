using TMPro;
using UnityEngine;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI _txtLives;

    [SerializeField]
    private TextMeshProUGUI _txtScore;

    [SerializeField]
    private Transform _startScreen;

    private void FixedUpdate()
    {
        UIManager.Instance.UpdateGameStats();
    }

    public void UpdateGameStats()
    {
        DamageablePlayer player = FindFirstObjectByType<DamageablePlayer>();

        Instance._txtScore.text = string.Format("{0:000}", Game.Instance.Score);
        Instance._txtLives.text = player.Lives.ToString();
    }

    public void ShowMainScreen()
    {
        Game.Instance.PauseGame(true);
        UIManager.Instance._startScreen.gameObject.SetActive(true);
    }

    public void HideMainScreen()
    {
        Game.Instance.PauseGame(false);
        UIManager.Instance._startScreen.gameObject.SetActive(false);
    }
}
