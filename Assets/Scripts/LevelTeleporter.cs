using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTeleporter : MonoBehaviour
{
    [SerializeField]
    private string _teleportToScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IDamageablePlayer player = collision.gameObject.GetComponent<IDamageablePlayer>();
        CheckTeleportLogic(player);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IDamageablePlayer player = collision.collider.gameObject.GetComponent<IDamageablePlayer>();
        CheckTeleportLogic(player);
    }

    private void CheckTeleportLogic(IDamageablePlayer player)
    {
        if (player != null)
        {
            SceneManager.LoadScene(_teleportToScene);
        }
    }
}
