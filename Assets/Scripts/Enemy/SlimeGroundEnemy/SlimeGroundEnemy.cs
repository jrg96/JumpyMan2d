using UnityEngine;

[RequireComponent(typeof(GroundEntityCollision), typeof(GroundEnemyCollision))]
public class SlimeGroundEnemy : MonoBehaviour
{
    private GroundEntityCollision _groundEntityCollision;
    private GroundEnemyCollision _groundEnemyCollision;

    private void Awake()
    {
        _groundEntityCollision = GetComponent<GroundEntityCollision>();
        _groundEnemyCollision = GetComponent<GroundEnemyCollision>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
