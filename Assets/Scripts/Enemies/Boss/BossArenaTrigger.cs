using UnityEngine;

public class BossArenaTrigger : MonoBehaviour
{
    [SerializeField] private BiofilmBoss biofilmBoss;
    [SerializeField] private GameObject arenaDoor;
    [SerializeField] private GameObject bossHealthBar;
    private bool hasStarted;

    private void OnEnable()
    {
        biofilmBoss.OnBossDefeated += HandleBossDefeated;
    }

    private void OnDisable()
    {
        biofilmBoss.OnBossDefeated -= HandleBossDefeated;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.TryGetComponent<PlayerMarker>(out _))
        {
            return;
        }
        if (hasStarted)
            return;
        hasStarted = true;
        arenaDoor.SetActive(true);
        bossHealthBar.SetActive(true);
        biofilmBoss.StartFight();
    }

    private void HandleBossDefeated()
    {
        bossHealthBar.SetActive(false);
    }

}
