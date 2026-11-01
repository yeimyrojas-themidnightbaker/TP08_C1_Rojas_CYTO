using UnityEngine;

public class PowerUpPickup : Pickable
{
    protected override void ApplyEffect(Collider2D other)
    {
        if (other.TryGetComponent<PlayerPowerUps>(out PlayerPowerUps playerPowerUps))
        {
            playerPowerUps.Activate(pickableData.PowerUpType, pickableData.PowerUpDuration);
        }
    }
}
