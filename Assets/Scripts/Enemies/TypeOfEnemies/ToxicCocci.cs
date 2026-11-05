using System.Collections;
using UnityEngine;

public class ToxicCocci : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private EnemyDataSo toxicCocciData;
    [SerializeField] private Projectile projectilePrefab;

    [Header("Components")]
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Transform visual;
    [SerializeField] private Transform firePoint;
    [SerializeField] private SfxEventSo sfxEvent;
    [SerializeField] private Animator animator;

    private bool isShooting;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = visual.localScale;
    }
    private void Update()
    {
        if (isShooting)
            return;

        Collider2D hit = Physics2D.OverlapCircle(transform.position, toxicCocciData.DangerRange, playerLayer);
        if (hit == null)
            return;
        StartCoroutine(ShootRoutine(hit.transform));
    }
    private IEnumerator ShootRoutine(Transform target)
    {
        isShooting = true;
        if (animator != null)
        {
            animator.Play(AnimatorStates.ToxicAnticipation, 0, 0f);
        }
        visual.localScale = originalScale * toxicCocciData.InflateSize;
        yield return new WaitForSeconds(toxicCocciData.WindUpTime);

        Vector2 direction = ((Vector2)target.position - (Vector2)firePoint.position).normalized;

        Projectile toxin = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        if(animator != null)
        {
        animator.Play(AnimatorStates.ToxicShoot, 0, 0f);
        }
        toxin.Init(direction);
        sfxEvent.Play(toxicCocciData.SpecialClip);

        visual.localScale = originalScale;

        yield return new WaitForSeconds(toxicCocciData.TimeBetweenShoots);
        isShooting = false;
    }
    private void OnDrawGizmosSelected()
    {
        if (toxicCocciData == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, toxicCocciData.DangerRange);
    }
}
