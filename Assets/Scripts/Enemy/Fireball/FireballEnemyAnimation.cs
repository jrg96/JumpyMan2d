using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(VerticalProjectileEnemyMovement))]
public class FireballEnemyAnimation : MonoBehaviour
{
    private VerticalProjectileEnemyMovement _projectileEnemyMovement;

    private void Awake()
    {
        _projectileEnemyMovement = GetComponent<VerticalProjectileEnemyMovement>();
    }

    private void FixedUpdate()
    {
        // If going down, flip the sprite
        if (_projectileEnemyMovement.MovementSpeed < 0)
        {
            Vector3 scale = transform.localScale;
            scale.y = Mathf.Abs(scale.x) * -1;
            transform.localScale = scale;
        }
    }
}
