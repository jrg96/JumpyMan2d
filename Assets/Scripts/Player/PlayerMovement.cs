using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerMovement : MonoBehaviour
{
    /*
     * Movement related properties
     */
    [SerializeField]
    private float _movementSpeed;
    public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }

    [SerializeField]
    private float _jumpForce;
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
