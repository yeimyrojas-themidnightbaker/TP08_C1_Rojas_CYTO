using UnityEngine;

[CreateAssetMenu(fileName = "Player", menuName = "Data/Player Data")]
public class PlayerDataSo : ScriptableObject
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 6f;
    public float MoveSpeed => moveSpeed;

    [SerializeField] private float jumpForce = 12f;
    public float JumpForce => jumpForce;

    [Range(0f, 1f)]
    [SerializeField] private float jumpCutMultiplier = 0.5f;
    public float JumpCutMultiplier => jumpCutMultiplier;

    [SerializeField] private int maxJumps = 2;
    public int MaxJumps => maxJumps;

    [SerializeField] private float groundCheckRadius = 0.15f;
    public float GroundCheckRadius => groundCheckRadius;

    [Header("Keys")]
    [SerializeField] private KeyCode[] leftKeys = { KeyCode.A, KeyCode.LeftArrow };
    public KeyCode[] LeftKeys => leftKeys;
    [SerializeField] private KeyCode[] rightKeys = { KeyCode.D, KeyCode.RightArrow }; 
    public KeyCode[] RightKeys => rightKeys;
    [SerializeField] private KeyCode[] jumpKeys = { KeyCode.Space};
    public KeyCode[] JumpKeys => jumpKeys;

    [Header("Attack")]
    [SerializeField] private KeyCode[] attackKeys = { KeyCode.J, KeyCode.Mouse0 };
    public KeyCode[] AttackKeys => attackKeys;

    [SerializeField] private KeyCode[] upKeys = {KeyCode.W, KeyCode.UpArrow };
    public KeyCode[] UpKeys => upKeys;

    [SerializeField] private KeyCode[] downKeys = { KeyCode.S, KeyCode.DownArrow };
    public KeyCode[] DownKeys => downKeys;

    [SerializeField] private int attackDamage = 1;
    public int AttackDamage => attackDamage;

    [SerializeField] private Vector2 attackSize = new Vector2(1.6f, 0.6f);
    public Vector2 AttackSize => attackSize;

    [SerializeField] private float attackCoolDown = 0.35f;
    public float AttackCoolDown => attackCoolDown;

    [Header("Health")]
    [SerializeField] private int maxHealth = 5;
    public int MaxHealth => maxHealth;

    [SerializeField] private float invulnerabilityDuration = 1f;
    public float InvulnerabilityDuration => invulnerabilityDuration;

    [SerializeField] private float blinkInterval = 0.1f;
    public float BlinkInterval => blinkInterval;

    [SerializeField] private Vector2 knockBackForce = new Vector2(6f, 4f);
    public Vector2 KnockBackForce => knockBackForce;

    [SerializeField] private float knockBackDuration = 0.2f;
    public float KnockBackDuration => knockBackDuration;

    [Header("Energy")]
    [SerializeField] private float maxAtp = 100f;
    public float MaxAtp => maxAtp;

    [SerializeField] private float atpPerHit = 8f;
    public float AtpPerHit => atpPerHit;

    [SerializeField] private float atpPerKill = 20f;
    public float AtpPerKill => atpPerKill;

    [SerializeField] private float healCost = 33f;
    public float HealCost => healCost;

    [SerializeField] private float healDuration =1f;
    public float HealDuration => healDuration;

    [SerializeField] private KeyCode[] healKeys = { KeyCode.L };
    public KeyCode[] HealKeys => healKeys;

    [Header("PowerUps")]
    [SerializeField] private float damageBoostMultiplier = 1.5f;
    public float DamageBoostMultiplier => damageBoostMultiplier;
    [SerializeField] private int extraJumps = 1;
    public int ExtraJumps => extraJumps;

    [SerializeField] private Color damageBoostColor = new Color(0.71f, 0.18f, 0.31f);
    public Color DamageBoostColor => damageBoostColor;
    [SerializeField] private Color shieldColor = new Color(0.09f, 0.93f, 0.88f);
    public Color ShieldColor => shieldColor;
    [SerializeField] private Color extraJumpColor = new Color(0.09f, 0.63f, 0.47f);
    public Color ExtraJumpColor => extraJumpColor;

    [Header("Shoot")]
    [SerializeField] private float shootCost = 10f;
    public float ShootCost => shootCost;
    [SerializeField] private float shootCooldown = 0.4f;
    public float ShootCooldown => shootCooldown;
    [SerializeField] private KeyCode[] shootKeys = { KeyCode.K };
    public KeyCode[] ShootKeys => shootKeys;

    [Header("Ring")]
    [SerializeField] private float ringCost = 25;
    public float RingCost => ringCost;
    [SerializeField] private float ringRadius = 2.5f;
    public float RingRadius => ringRadius;
    [SerializeField] private int ringDamage = 2;
    public int RingDamage => ringDamage;
    [SerializeField] private GameObject ringVfx;
    public GameObject RingVfx => ringVfx;

    [Header("Audio")]
    [SerializeField] private AudioClip attackClip;
    public AudioClip AttackClip => attackClip;
    [SerializeField] private AudioClip shootClip;
    public AudioClip ShootClip => shootClip;
    [SerializeField] private AudioClip ringClip;
    public AudioClip RingClip => ringClip;
    [SerializeField] private AudioClip hurtClip;
    public AudioClip HurtClip => hurtClip;
    [SerializeField] private AudioClip diedClip;
    public AudioClip DiedClip => diedClip;
    [SerializeField] private AudioClip jumpClip;
    public AudioClip JumpClip => jumpClip;
    [SerializeField] private AudioClip landClip;
    public AudioClip LandClip => landClip;
    [SerializeField] private AudioClip stepClip;
    public AudioClip StepClip => stepClip;
    //for steps
    [SerializeField] private float stepInterval;
    public float StepInterval => stepInterval;

    [SerializeField] private AudioClip healClip;
    public AudioClip HealClip => healClip;


}
