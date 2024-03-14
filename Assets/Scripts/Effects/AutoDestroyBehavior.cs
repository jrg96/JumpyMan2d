using UnityEngine;

public class AutoDestroyBehavior : MonoBehaviour
{
    public void AutoDestroy()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
