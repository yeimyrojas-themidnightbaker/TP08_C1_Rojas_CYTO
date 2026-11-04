using System.Collections;
using UnityEngine;

public class EnemyHitFlash : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private EnemyDataSo enemyData;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Coroutine currentFlash;
    private Color colorBeforeFlash;

    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += HandleHitColor;
    }
    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= HandleHitColor;
    }

    private void HandleHitColor(int currentHealth)
    {
        if (!(currentHealth > 0 && currentHealth < enemyData.MaxHealth))
            return;
        if(currentFlash != null)
        {
            StopCoroutine(currentFlash);
            spriteRenderer.color = colorBeforeFlash;
        }
        colorBeforeFlash = spriteRenderer.color;
        currentFlash = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.color = enemyData.HitFlashColor;
        yield return new WaitForSeconds(enemyData.HitFlashDuration);
        spriteRenderer.color = colorBeforeFlash;
        currentFlash = null;
    }
}
