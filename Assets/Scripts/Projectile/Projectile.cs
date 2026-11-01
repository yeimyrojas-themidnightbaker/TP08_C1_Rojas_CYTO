using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileDataSo projectileData;
    private Vector2 direction;

    private void Start()
    {
        Destroy(gameObject, projectileData.LifeTime);
    }

    private void FixedUpdate()
    {
        float step = projectileData.Speed * Time.fixedDeltaTime;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, step, projectileData.HitLayer);

        if (hit.collider != null)
        {
            if (hit.collider.TryGetComponent<PlayerMarker>(out _))
            {
                if (hit.collider.TryGetComponent(out PlayerHealth playerHealth))
                {
                    playerHealth.TakeHit(Mathf.Sign(direction.x));
                }
            }
            if (hit.collider.TryGetComponent<EnemyMarker>(out _))
            {
                if(hit.collider.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(projectileData.Damage);
                }
            }
            if (projectileData.HitVfx != null)
            {
                Instantiate(projectileData.HitVfx, hit.point, Quaternion.identity);

            }
            Destroy(gameObject);
            return;
        }
        transform.position += (Vector3)(direction * step);
    }
    public void Init(Vector2 dir)
    {
        direction = dir;
        transform.right = direction;
    }
}
