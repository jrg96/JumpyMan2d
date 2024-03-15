using TMPro;
using UnityEngine;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField]
    private TextMeshProUGUI _txtLives;

    [SerializeField]
    private TextMeshProUGUI _txtScore;

    private void FixedUpdate()
    {
        UIManager.Instance.UpdateGameStats();
    }

    public void UpdateGameStats()
    {
        DamageablePlayer player = FindFirstObjectByType<DamageablePlayer>();

        Instance._txtScore.text = string.Format("{0:000}", Game.Instance.Score);
        Instance._txtLives.text = player.Lives.ToString();

        if (player.Lives == 0)
        {
            Game.Instance.GameOver();
        }
    }
}
