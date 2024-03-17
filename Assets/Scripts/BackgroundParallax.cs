using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField]
    private Transform bg0;
    [SerializeField]
    private Transform bg1;
    [SerializeField]
    private Transform bg2;

    private float factor0 = 1f;
    private float factor1 = 1 / 2f;
    private float factor2 = 1 / 4f;

    private float displacement;
    private float initCamPosFrame;
    private float nextCamPosFrame;

    private void Update()
    {
        initCamPosFrame = transform.position.x;
    }

    private void LateUpdate()
    {
        nextCamPosFrame = transform.position.x;
        displacement = (nextCamPosFrame - initCamPosFrame);  

        bg0.position = new Vector3(bg0.position.x + displacement * factor0, bg0.position.y, bg0.position.z);
        bg1.position = new Vector3(bg1.position.x + displacement * factor1, bg1.position.y, bg1.position.z);
        bg2.position = new Vector3(bg2.position.x + displacement * factor2, bg2.position.y, bg2.position.z);
    }
}
