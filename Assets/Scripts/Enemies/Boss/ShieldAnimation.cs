using UnityEngine;

public class ShieldAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private EnemyHealth enemyHealth;

    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += HandleHit;
    }

    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= HandleHit;
    }

    private void HandleHit(int currentHealth)
    {
        // Suggestion: 2 y 1 son números mágicos atados al maxHealth = 3 de BossShield.asset. Si cambiás la vida del escudo, las grietas dejan de coincidir.
        // Calculalo en función de enemyHealth.MaxHealth o exponé los umbrales en el SO.
        if (currentHealth == 2)
        {
            if (animator != null)
            {
                animator.Play(AnimatorStates.ShieldCrack1, 0, 0f);
            }
        }
        if (currentHealth == 1)
        {
            if (animator != null)
            {
                animator.Play(AnimatorStates.ShieldCrack2, 0, 0f);
            }
        }
    }
}
