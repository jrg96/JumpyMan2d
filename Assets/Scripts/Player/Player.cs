using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(DamageablePlayer))]
public class Player : GenericSingleton<Player>
{
    private PlayerMovement _playerMovement;
    private DamageablePlayer _damageablePlayer;

    private new void Awake()
    {
        base.Awake();
        _playerMovement = GetComponent<PlayerMovement>();
        _damageablePlayer = GetComponent<DamageablePlayer>();
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
