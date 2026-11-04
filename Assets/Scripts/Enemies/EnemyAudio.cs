using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    [SerializeField] private EnemyDataSo enemyData;
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private SfxEventSo sfxEvent;

    private void OnEnable()

    {
        enemyHealth.OnDied += HandleDiedAudio;
        enemyHealth.OnHealthChanged += HandleHitClip;
    }
    private void OnDisable()
    {
        enemyHealth.OnDied -= HandleDiedAudio;
        enemyHealth.OnHealthChanged -= HandleHitClip;
    }

    private void HandleDiedAudio()
    {
        sfxEvent.Play(enemyData.DeathClip);
    }
    private void HandleHitClip(int currentHealth)
    {
        if (currentHealth > 0 && currentHealth < enemyData.MaxHealth)
        {
            sfxEvent.Play(enemyData.HitClip);
        }
    }

}
