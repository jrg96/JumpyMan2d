using System.Collections;
using UnityEngine;

public interface IMoveableEntity
{
    public bool InnerMovementActive { get; set; }
    public float MovementSpeed { get; }
    public void ApplyKnockbackForce(Vector2 knockback, float delay, bool resetSpeed);
}
