using UnityEngine;

public class GlucosePickup : Pickable
{
    protected override void ApplyEffect(Collider2D player)
    {
        if(player.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.AddLife(pickableData.Amount);
        }
    }
}
