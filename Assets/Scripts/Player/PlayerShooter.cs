using UnityEngine;
using UnityEngine.Events;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerEnergy playerEnergy;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameManager gameManager;
    private float shootTimer;

    public event UnityAction OnShoot;
    public event UnityAction OnRing;

    private void Update()
    {
        if (gameManager.IsPaused)
            return;
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        if (!AnyKeyDown(playerData.ShootKeys) || shootTimer > 0)
            return;
        if (AnyKeyHeld(playerData.UpKeys))
        {
            if (!playerEnergy.TrySpend(playerData.RingCost))
                return;
            ReleaseRing();
        }

        else
        {
            if (!playerEnergy.TrySpend(playerData.ShootCost))
                return;
            Shoot();
        }

        shootTimer = playerData.ShootCooldown;
    }

    private void Shoot()
    {
        float facing = playerMovement.FacingDirection;
        Vector3 spawnPos = transform.position + new Vector3(firePoint.localPosition.x * facing, firePoint.localPosition.y, 0f);
        Projectile spawnProjectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        spawnProjectile.Init(new Vector2(facing, 0f));
        OnShoot?.Invoke();
    }

    private void ReleaseRing()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, playerData.RingRadius, enemyLayer);
        foreach (Collider2D hit in hits)
        {
            if (hit.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
            {
                enemyHealth.TakeDamage(playerData.RingDamage);
            }
        }
        if (playerData.RingVfx != null)
        {
            Instantiate(playerData.RingVfx, transform.position, Quaternion.identity);
        }
        OnRing?.Invoke();
    }

    private void OnDrawGizmosSelected()
    {
        if (playerData == null)
            return;
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, playerData.RingRadius);
    }
    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKeyDown(key)) return true;
        return false;
    }

    private bool AnyKeyHeld(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKey(key)) return true;
        return false;
    }
}
