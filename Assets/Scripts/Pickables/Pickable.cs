using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    [SerializeField] protected PickableDataSo pickableData;
    [SerializeField] private SfxEventSo sfxEvent;
    [SerializeField] private SaveDataSo saveData;
    private bool isPicked;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPicked)
            return;

        if (!other.TryGetComponent<PlayerMarker>(out _))
            return;
        isPicked = true;

        if (pickableData.AtlasEntry != null)
        {
            saveData.MarkDiscovered(pickableData.AtlasEntry);
        }

        if (pickableData.PickupParticles != null)
        {
            Instantiate(pickableData.PickupParticles, transform.position, Quaternion.identity);
        }
        if (pickableData.PickupClip != null)
        {
            sfxEvent.Play(pickableData.PickupClip);
        }
        ApplyEffect(other);
        Destroy(gameObject);
    }
    protected abstract void ApplyEffect(Collider2D other);
}
