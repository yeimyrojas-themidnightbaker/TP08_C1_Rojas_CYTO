using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerEnergy playerEnergy;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;
    private float shootTimer;

    private void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        if (!AnyKeyDown(playerData.ShootKeys) || shootTimer > 0)
            return;
        if (!playerEnergy.TrySpend(playerData.ShootCost))
            return;
        float facing = playerMovement.FacingDirection;
        Vector3 spawnPos = transform.position + new Vector3(firePoint.localPosition.x * facing, firePoint.localPosition.y, 0f);
        Projectile spawnProjectile = Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        spawnProjectile.Init(new Vector2(facing, 0f));
        shootTimer = playerData.ShootCooldown;
    }
    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKeyDown(key)) return true;
        return false;
    }
}
