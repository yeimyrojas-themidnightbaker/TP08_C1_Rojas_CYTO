using UnityEngine;

public class BackgroundZoneTrigger : MonoBehaviour
{
    [SerializeField] private BackgroundZone zone;
    [SerializeField] private BackgroundZone[] allZones;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.TryGetComponent<PlayerMarker>(out _))
            return;
        foreach(BackgroundZone backgroundZone in allZones)
        {
            if (backgroundZone == zone)
                backgroundZone.FadeTo(1f);
            else
                backgroundZone.FadeTo(0f);
        }
    }
}
