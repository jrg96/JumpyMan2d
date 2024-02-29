using UnityEngine;

/// <summary>
/// Class used for collision detection for ground enemies, detects
/// 3 types of collision:
/// 
/// *) Near falling
/// *) Other enemy collision
/// *) Horizontal ground collision
/// 
/// </summary>
public class GroundEnemyCollision : MonoBehaviour
{
    [SerializeField]
    private float _groundRayLength;
    [SerializeField]
    private LayerMask _groundLayerMask;
    public bool FallingLeft { get; private set; }
    public bool FallingRight { get; private set; }

    private SpriteRenderer _spriteRenderer;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CalculateFallScenario();
    }

    private void CalculateFallScenario()
    {
        // calculate top right and top left corner of the enemy
        Vector2 center = new Vector2(transform.position.x, transform.position.y);
        Vector2 bottomLeft = center - new Vector2(_spriteRenderer.bounds.extents.x, _spriteRenderer.bounds.extents.y);
        Vector2 bottomRight = center + new Vector2(_spriteRenderer.bounds.extents.x, -_spriteRenderer.bounds.extents.y);

        // Cast both rays on both sides to check where it is falling (if falling at all)
        FallingLeft = !Physics2D.Raycast(bottomLeft, Vector2.down, _groundRayLength, _groundLayerMask);
        FallingRight = !Physics2D.Raycast(bottomRight, Vector2.down, _groundRayLength, _groundLayerMask);
    }
}
