using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    [SerializeField]
    private Vector2 _playerInitialCoordinates;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Manually set initial coordinates for player to cover
        // fall out scenarios when loading scene
        Player.Instance.gameObject.transform.position = _playerInitialCoordinates;

        // Since player is a singleton, set cinemachine reference to singleton
        // on scene loaded
        CinemachineVirtualCamera camera = FindFirstObjectByType<CinemachineVirtualCamera>();
        camera.Follow = Player.Instance.gameObject.transform;
    }
}
