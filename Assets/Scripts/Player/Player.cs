using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : GenericSingleton<Player>
{
    /*
     * Player properties
     */
    [SerializeField]
    private int _lives;
    public int Lives { get => _lives; set => _lives = value; }
    public bool IsInGround { get; set; }
    public bool IsImmune { get; set; }

    [SerializeField]
    private PlayerMovement _playerMovement;


    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        /*
         * Configurations for player
         */
        _playerMovement.MovementSpeed = 5f;
        _playerMovement.JumpForce = 3f;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
