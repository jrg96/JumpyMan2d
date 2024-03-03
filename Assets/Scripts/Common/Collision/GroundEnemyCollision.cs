using System;
using System.Linq;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    private int _groundLayerNumber;
    public bool FallingLeft { get; private set; }
    public bool FallingRight { get; private set; }

    [SerializeField]
    private float _rightLeftRayLength;
    [SerializeField]
    private string[] _enemyTags;
    public bool LeftGroundCollision { get; private set; }
    public bool RightGroundCollision { get; private set; }
    public bool LeftEnemyCollision { get; private set; }
    public bool RightEnemyCollision { get; private set; }


    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _groundLayerNumber = (int)Mathf.Log(_groundLayerMask.value, 2);
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CalculateFallScenario();
        CheckHorizontalCollision();
    }

    private void CalculateFallScenario()
    {
        FallingLeft = false;
        FallingRight = false;

        // calculate top right and top left corner of the enemy
        Vector2 center = new Vector2(transform.position.x, transform.position.y);
        Vector2 bottomLeft = center - new Vector2(_spriteRenderer.bounds.extents.x, _spriteRenderer.bounds.extents.y);
        Vector2 bottomRight = center + new Vector2(_spriteRenderer.bounds.extents.x, -_spriteRenderer.bounds.extents.y);

        // Cast both rays on both sides to check where it is falling (if falling at all)
        FallingLeft = !Physics2D.Raycast(bottomLeft, Vector2.down, _groundRayLength, _groundLayerMask);
        FallingRight = !Physics2D.Raycast(bottomRight, Vector2.down, _groundRayLength, _groundLayerMask);

        // Debug raycasts
        Debug.DrawRay(bottomLeft, Vector2.down * _rightLeftRayLength, Color.red);
        Debug.DrawRay(bottomRight, Vector2.down * _rightLeftRayLength, Color.red);
    }

    private void CheckHorizontalCollision()
    {
        LeftGroundCollision = false;
        LeftEnemyCollision = false;
        RightGroundCollision = false;
        RightEnemyCollision = false;

        Vector2 center = new Vector2(transform.position.x, transform.position.y);

        RaycastHit2D leftCollision = Physics2D.Raycast(center, Vector2.left, _rightLeftRayLength);
        RaycastHit2D rightCollision = Physics2D.Raycast(center, Vector2.right, _rightLeftRayLength);

        // if colliders are not null, means we're hitting something
        if (leftCollision.collider != null)
        {
            if (leftCollision.collider.gameObject.layer == _groundLayerNumber)
            {
                LeftGroundCollision = true;
            }
            else if (_enemyTags.Contains(leftCollision.collider.tag))
            {
                LeftEnemyCollision = true;
            }
        }

        if (rightCollision.collider != null)
        {
            if (rightCollision.collider.gameObject.layer == _groundLayerNumber)
            {
                RightGroundCollision = true;
            }
            else if (_enemyTags.Contains(rightCollision.collider.tag))
            {
                RightEnemyCollision = true;
            }
        }

        // Debug raycasts
        Debug.DrawRay(center, Vector2.right * _rightLeftRayLength, Color.red);
        Debug.DrawRay(center, Vector2.left * _rightLeftRayLength, Color.red);
    }
}
