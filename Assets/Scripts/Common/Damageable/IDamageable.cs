using UnityEngine;

public interface IDamageable
{
    int Lives { get; }
    int MaxLives { get; }
    bool Immune { get; }
    void OnHit(int damage, Vector2 knockback, bool resetSpeed = false);
    void OnHit(int damage);
    void AddLives(int lives);
}
