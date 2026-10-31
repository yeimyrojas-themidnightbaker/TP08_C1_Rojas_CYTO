using UnityEngine;

public abstract class Pickable : MonoBehaviour
{
    [SerializeField] protected PickableDataSo pickableData;
    private bool isPicked;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isPicked)
            return;

        if (!other.TryGetComponent<PlayerMarker>(out _))
            return;
        isPicked = true;
        if (pickableData.PickupParticles != null)
        {
            Instantiate(pickableData.PickupParticles, transform.position, Quaternion.identity);
        }
        ApplyEffect(other);
        Destroy(gameObject);
    }
    protected abstract void ApplyEffect(Collider2D other);
}
