using UnityEngine;
using UnityEngine.Events;

public class BiofilmBoss : MonoBehaviour
{
    [SerializeField] private EnemyHealth[] shields;
    [SerializeField] private EnemyHealth core;
    [SerializeField] private Collider2D coreCollider;
    [SerializeField] private GameObject biofilmWall;
    [SerializeField] private ToxicCocci coreShooter;
    [SerializeField] private Animator animator;
    [SerializeField] private Animator animatorBody;

    private BossState state = BossState.Waiting;
    private int shieldsRemaining;
    public event UnityAction OnBossDefeated;
    public event UnityAction OnFightStarted;
    private void Start()
    {
        shieldsRemaining = shields.Length;
        coreCollider.enabled = false;
        coreShooter.enabled = false;

    }

    private void OnEnable()
    {
        foreach (EnemyHealth shield in shields)
        {
            shield.OnDied += HandleShieldDied;
        }
        core.OnDied += HandleCoreDied;
    }
    private void OnDisable()
    {
        foreach (EnemyHealth shield in shields)
        {
            shield.OnDied -= HandleShieldDied;
        }
        core.OnDied -= HandleCoreDied;
    }

    private void HandleShieldDied()
    {
        shieldsRemaining--;
        if(shieldsRemaining <= 0)
        {
            ChangeState(BossState.Exposed);
        }
    }

    private void HandleCoreDied()
    {
        ChangeState(BossState.Defeated);
    }

    private void ChangeState(BossState newState)
    {
        if (state == newState)
            return;
        state = newState;
        switch (newState)
        {
            case BossState.Waiting:
                break;
            case BossState.Shielded:
                coreCollider.enabled = false;
                coreShooter.enabled = false;
                OnFightStarted?.Invoke();
                break;
            case BossState.Exposed:
                coreCollider.enabled = true;
                coreShooter.enabled = true;
                if(animator != null)
                {
                animator.Play(AnimatorStates.BossCoreExposed);
                }
                break;
            case BossState.Defeated:
                biofilmWall.SetActive(false);
                animatorBody.Play(AnimatorStates.BossBodyCollapse);
                OnBossDefeated?.Invoke();
                break;
        }
    }

    public void StartFight()
    {
        ChangeState(BossState.Shielded);
    }
}
