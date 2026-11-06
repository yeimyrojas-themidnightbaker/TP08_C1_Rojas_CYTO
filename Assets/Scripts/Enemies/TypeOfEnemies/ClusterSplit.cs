using System.Collections;
using UnityEngine;

public class ClusterSplit : MonoBehaviour
{
    [SerializeField] private EnemyDataSo enemyData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SfxEventSo sfxEvent;
    [SerializeField] private Animator animator;

    private void Start()
    {
        StartCoroutine(SplitCoroutine());
    }
    private IEnumerator SplitCoroutine()
    {
        yield return new WaitForSeconds(enemyData.SplitTime - enemyData.WarningTime);
        if (animator != null)
        {
            animator.Play(AnimatorStates.ClusterSplit, 0, 0f);
        }

        yield return new WaitForSeconds(enemyData.WarningTime);

        GameObject smallCluster = enemyData.SmallCluster;
        sfxEvent.Play(enemyData.SpecialClip);
        GameObject right = Instantiate(smallCluster, transform.position + new Vector3(enemyData.SplitOffsetX, enemyData.SplitOffsetY, 0f), Quaternion.identity);
        right.GetComponent<ClusterPatrol>().SetStartDirection(true);
        GameObject left = Instantiate(smallCluster, transform.position + new Vector3(-enemyData.SplitOffsetX, enemyData.SplitOffsetY, 0f), Quaternion.identity);
        left.GetComponent<ClusterPatrol>().SetStartDirection(false);
        Destroy(gameObject);
    }
}
