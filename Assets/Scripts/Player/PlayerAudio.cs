using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerShooter playerShooter;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerHealing playerHealing;

    private float stepTimer;

    private void Update()
    {
        if(playerMovement.IsGrounded && playerMovement.IsWalking)
        {
            stepTimer -= Time.deltaTime;
            if(stepTimer <= 0)
            {
                audioSource.PlayOneShot(playerData.StepClip);
                stepTimer = playerData.StepInterval;
            }
        }
        else
        {
            stepTimer = 0;
        }
    }
    private void OnEnable()
    {
        playerAttack.OnAttack += HandleAttackAudio;
        playerShooter.OnShoot += HandleShootAudio;
        playerShooter.OnRing += HandleRingAudio;
        playerHealth.OnDied += HandleDiedAudio;
        playerHealth.OnTakeDamage += HandleHurtAudio;
        playerMovement.OnJumped += HandleJumpAudio;
        playerMovement.OnLanded += HandleLandAudio;
        playerHealing.OnHealed += HandleHealAudio;
    }

    private void OnDisable()
    {
        playerAttack.OnAttack -= HandleAttackAudio;
        playerShooter.OnShoot -= HandleShootAudio;
        playerShooter.OnRing -= HandleRingAudio;
        playerHealth.OnDied -= HandleDiedAudio;
        playerHealth.OnTakeDamage -= HandleHurtAudio;
        playerMovement.OnJumped -= HandleJumpAudio;
        playerMovement.OnLanded -= HandleLandAudio;
        playerHealing.OnHealed -= HandleHealAudio;
    }


    private void HandleAttackAudio(AttackDirection direciton)
    {
        audioSource.PlayOneShot(playerData.AttackClip);
    }

    private void HandleShootAudio()
    {
        audioSource.PlayOneShot(playerData.ShootClip);
    }

    private void HandleRingAudio()
    {
        audioSource.PlayOneShot(playerData.RingClip);
    }

    private void HandleDiedAudio()
    {
        audioSource.PlayOneShot(playerData.DiedClip);
        enabled = false;
    }
    private void HandleHurtAudio(float arg0)
    {
        audioSource.PlayOneShot(playerData.HurtClip);
    }
    private void HandleJumpAudio()
    {
        audioSource.PlayOneShot(playerData.JumpClip);
    }
    private void HandleLandAudio()
    {
        audioSource.PlayOneShot(playerData.LandClip);
    }
    private void HandleHealAudio()
    {
        audioSource.PlayOneShot(playerData.HealClip);
    }
}
