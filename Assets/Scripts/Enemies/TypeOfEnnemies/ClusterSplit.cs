using System.Collections;
using UnityEngine;

public class ClusterSplit : MonoBehaviour
{
    [SerializeField] private EnemyDataSo enemyData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SfxEventSo sfxEvent;

    private void Start()
    {
        StartCoroutine(SplitCoroutine());
    }
    private IEnumerator SplitCoroutine()
    {
        yield return new WaitForSeconds(enemyData.SplitTime - enemyData.WarningTime);
        spriteRenderer.color = Color.red;
        sfxEvent.Play(enemyData.SpecialClip);

        yield return new WaitForSeconds(enemyData.WarningTime);

        GameObject smallCluster = enemyData.SmallCluster;
        GameObject right = Instantiate(smallCluster, transform.position + new Vector3(enemyData.SplitOffsetX, enemyData.SplitOffsetY, 0f), Quaternion.identity);
        right.GetComponent<ClusterPatrol>().SetStartDirection(true);                                          
        GameObject left = Instantiate(smallCluster, transform.position + new Vector3(-enemyData.SplitOffsetX, enemyData.SplitOffsetY, 0f), Quaternion.identity);
        left.GetComponent<ClusterPatrol>().SetStartDirection(false);
        Destroy(gameObject);
    }
}
