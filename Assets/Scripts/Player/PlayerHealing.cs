using UnityEngine;
using UnityEngine.Events;

public class PlayerHealing : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerEnergy playerEnergy;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameManager gameManager;
    private float healTimer;
    private bool isHealing;
    public bool IsHealing => isHealing;

    public event UnityAction OnHealed;

    private void OnEnable()
    {
        playerHealth.OnTakeDamage += HandleTakeDamage;
        playerHealth.OnDied += HandleDied;
    }

    private void OnDisable()
    {
        playerHealth.OnTakeDamage -= HandleTakeDamage;
        playerHealth.OnDied -= HandleDied;
    }

    private void Update()
    {
        if (gameManager.IsPaused)
            return;
        if (!AnyKeyHeld(playerData.HealKeys) || !playerMovement.IsGrounded || playerHealth.IsFullHealth || !playerEnergy.CanAfford(playerData.HealCost))
        {
            StopHealing();
            return;
        }
        isHealing = true;
        healTimer += Time.deltaTime;
        if (healTimer >= playerData.HealDuration)
        {
            if(playerEnergy.TrySpend(playerData.HealCost))
            {
                playerHealth.AddLife(1);
                OnHealed?.Invoke();
            }
            healTimer = 0f;
        }
    }

    private void StopHealing()
    {
        isHealing = false;
        healTimer = 0f;
    }

    private void HandleTakeDamage(float direction)
    {
        StopHealing();
    }

    private void HandleDied()
    {
        StopHealing();
        enabled = false;
    }
    private bool AnyKeyHeld(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
        {
            if (Input.GetKey(key))
                return true;
        }
        return false;
    }
}
