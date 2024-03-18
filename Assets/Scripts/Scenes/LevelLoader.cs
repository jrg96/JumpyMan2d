using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private float _waitTimeSeconds;

    [SerializeField]
    private TextMeshProUGUI txtLives;

    [SerializeField]
    private TextMeshProUGUI txtWorld;

    private void Start()
    {
        IDamageablePlayer player = Player.Instance.gameObject.GetComponent<IDamageablePlayer>();
        txtLives.text = "x" + player.Lives;
        txtWorld.text = Game.Instance.LevelToTeleport;

        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(_waitTimeSeconds);
        SceneManager.LoadScene(Game.Instance.LevelToTeleport);
    }
}
