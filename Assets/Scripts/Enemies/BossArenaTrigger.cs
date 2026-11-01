using UnityEngine;

public class BossArenaTrigger : MonoBehaviour
{
    [SerializeField] private BiofilmBoss biofilmBoss;
    [SerializeField] private GameObject arenaDoor;
    [SerializeField] private GameObject bossHealthBar;
    private bool hasStarted;

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

}
