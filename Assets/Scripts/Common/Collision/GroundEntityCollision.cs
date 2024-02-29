using UnityEngine;

/// <summary>
/// Class used to detected if an entity (enemy or player) is somehow hitting
/// the ground (useful to detected if jumping is allowed)
/// </summary>
public class GroundEntityCollision : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;
    public LayerMask LayerMask { get => _layerMask; set => _layerMask = value; }

    [SerializeField]
    private float _radius;
    public float Radius { get => _radius; set => _radius = value; }

    [SerializeField]
    private float _groundRayDist;
    public float GroundRayDistance { get => _groundRayDist; set => _groundRayDist = value; }

    private bool _isInGround;
    public bool IsInGround { get => _isInGround; private set => _isInGround = value; }

    private void Update()
    {
        // Check if player is colliding with the specified layer
        _isInGround = Physics2D.CircleCast(transform.position, Radius, Vector3.down, GroundRayDistance, LayerMask);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
