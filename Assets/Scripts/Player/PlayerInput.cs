using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float GetHorizontalAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public float GetVerticalAxis()
    {
        return Input.GetAxisRaw("Vertical");
    }

    public Vector3 GetDirection()
    {
        return new Vector3(GetHorizontalAxis(), GetVerticalAxis()).normalized;
    }

    public bool IsJumpKeyPressed()
    {
        return Input.GetKeyDown(KeyCode.Space);
    }
}
