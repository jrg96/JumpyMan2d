using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalProjectileEnemyMovement : MonoBehaviour, IMoveableEntity
{
    public bool InnerMovementActive { get; set; }

    public float MovementSpeed 
    { 
        get
        {
            if (_rigidBody != null)
            {
                return _rigidBody.velocity.y;
            }

            return 0;
        } 
    }

    [SerializeField]
    private float _forceApplied;
    public float ForceApplied { get => _forceApplied; set => _forceApplied = value; }

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // At creation, apply a vertical force to move the projectile
        // vertically
        _rigidBody.AddForce(Vector2.up * ForceApplied);
    }

    void Update()
    {
    }
}
