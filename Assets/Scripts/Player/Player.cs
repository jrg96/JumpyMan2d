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

    public bool IsImmune { get; set; }

    [SerializeField]
    private PlayerMovement _playerMovement;


    private new void Awake()
    {
        base.Awake();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
