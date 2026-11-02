using UnityEngine;

public class EnemyScore : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private EnemyDataSo enemyData;
    [SerializeField] private RunProgressSo runProgressSo;

    private void OnEnable()
    {
        enemyHealth.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        enemyHealth.OnDied -= HandleDied;
    }
    private void HandleDied()
    {
        runProgressSo.AddScore(enemyData.Score);    
    }
}
