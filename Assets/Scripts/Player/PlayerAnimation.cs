using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerShooter playerShooter;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerHealing playerHealing;

    private const float WalkThreshold = 0.1f;
    private const float JumpThreshold = 0.5f;

    private int currentState;
    private int actionHash;

    private void OnEnable()
    {
        playerAttack.OnAttack += HandleAttack;
        playerShooter.OnShoot += HandleShoot;
        playerShooter.OnRing += HandleRing;
        playerHealth.OnTakeDamage += HandleTakeDamage;
        playerHealth.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        playerAttack.OnAttack -= HandleAttack;
        playerShooter.OnShoot -= HandleShoot;
        playerShooter.OnRing -= HandleRing;
        playerHealth.OnTakeDamage -= HandleTakeDamage;
        playerHealth.OnDied -= HandleDied;
    }


    private void Update()
    {
        if (actionHash != 0)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            if (info.shortNameHash != actionHash)
                return;
            if (info.normalizedTime < 1f)
                return;
            actionHash = 0;
        }
        if (!playerMovement.IsGrounded)
        {
            if (rb.linearVelocity.y > JumpThreshold)
            {
                PlayAnimation(AnimatorStates.Jump);
            }
            else if (rb.linearVelocity.y < -JumpThreshold)
            {
                PlayAnimation(AnimatorStates.Fall);
            }
        }
        else
        {
            if(playerHealing.IsHealing)
            {
                PlayAnimation(AnimatorStates.Heal);
            }
            else if (Mathf.Abs(rb.linearVelocity.x) > WalkThreshold)
            {
                PlayAnimation(AnimatorStates.Walk);
            }
            else
            {
                PlayAnimation(AnimatorStates.Idle);
            }
        }

    }
    private void HandleAttack(AttackDirection direction)
    {
        switch (direction)
        {
            case AttackDirection.Side:
                PlayAction(AnimatorStates.Attack);
                break;
            case AttackDirection.Up:
                PlayAction(AnimatorStates.AttackUp);
                break;
            case AttackDirection.Down:
                PlayAction(AnimatorStates.AttackDown);
                break;
        }
    }

    private void HandleShoot()
    {
        PlayAction(AnimatorStates.Shoot);
    }

    private void HandleRing()
    {
        PlayAction(AnimatorStates.Ring);
    }

    private void HandleTakeDamage(float direction)
    {
        PlayAction(AnimatorStates.Hurt);
    }

    private void HandleDied()
    {
        PlayAction(AnimatorStates.Lysis);
        enabled = false;
    }

    private void PlayAction(int state)
    {
        actionHash = state;
        currentState = state;
        animator.Play(state, 0, 0f);
    }
    private void PlayAnimation(int state)
    {
        if (state == currentState)
            return;
        animator.Play(state);
        currentState = state;
    }
}
