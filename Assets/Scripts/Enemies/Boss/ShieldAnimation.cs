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
