using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerEnergy playerEnergy;
    [SerializeField] private PlayerPowerUps playerPowerUps;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SaveDataSo saveData;
    [SerializeField] private ShopItemSo attackDamageUpgrade;

    [Header("Attack Points")]
    [SerializeField] private Transform attackPointSide;
    [SerializeField] private Transform attackPointUp;
    [SerializeField] private Transform attackPointDown;
    [SerializeField] private LayerMask enemyLayer;

    public event UnityAction<AttackDirection> OnAttack;

    private float attackTimer;
    private int attackDamage;

    private void Start()
    {
        attackDamage = playerData.AttackDamage;
        if(saveData.HasUpgrade(attackDamageUpgrade.UpgradeType))
        {
            attackDamage += attackDamageUpgrade.UpgradeValue;
        }
    }
    private void OnEnable()
    {
        playerHealth.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        playerHealth.OnDied -= HandleDied;
    }

    private void Update()
    {
        if (gameManager.IsPaused)
            return;
        attackTimer -= Time.deltaTime;
        if (AnyKeyDown(playerData.AttackKeys) && attackTimer <= 0)
        {
            Attack();
            attackTimer = playerData.AttackCoolDown;
        }
    }

    private void Attack()
    {
        Vector2 center;
        AttackDirection direction;
        Vector2 size = playerData.AttackSize;
        if (AnyKeyHeld(playerData.UpKeys))
        {
            center = attackPointUp.position;
            size = new Vector2(size.y, size.x);
            direction = AttackDirection.Up;
        }
        else if (AnyKeyHeld(playerData.DownKeys) && !playerMovement.IsGrounded)
        {
            center = attackPointDown.position;
            size = new Vector2(size.y, size.x);
            direction = AttackDirection.Down;
        }
        else
        {
            Vector2 side = attackPointSide.localPosition;
            center = (Vector2)transform.position + new Vector2(side.x * playerMovement.FacingDirection, side.y);
            direction = AttackDirection.Side;
        }
        OnAttack?.Invoke(direction);

        //comportamiento de ataque a enemigo

        Collider2D[] hits = Physics2D.OverlapBoxAll(center, size, 0f, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            if(hit.TryGetComponent(out EnemyHealth enemyHealth))
            {
                int damage = attackDamage;
                if(playerPowerUps.IsDamageBoosted)
                {
                    damage = Mathf.CeilToInt(damage * playerData.DamageBoostMultiplier); //redondear hacia arriba y volver a un int
                }
                bool killed = enemyHealth.TakeDamage(damage);
                playerEnergy.AddAtp(playerData.AtpPerHit);
                if(killed)
                {
                    playerEnergy.AddAtp(playerData.AtpPerKill);
                }
            }

        }

    }

    private void OnDrawGizmosSelected()
    {
        if (playerData == null || attackPointSide == null || attackPointUp == null || attackPointDown == null) return;
        Vector2 s = playerData.AttackSize;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPointSide.position, s);
        Gizmos.DrawWireCube(attackPointUp.position, new Vector2(s.y, s.x));
        Gizmos.DrawWireCube(attackPointDown.position, new Vector2(s.y, s.x));
    }

    private void HandleDied()
    {
        enabled = false;
    }
    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKeyDown(key)) return true;
        return false;
    }

    private bool AnyKeyHeld(KeyCode[] keys)
    {
        foreach(KeyCode key in keys)
            if(Input.GetKey(key)) return true;
        return false;
    }
}
