using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float lifeTime = 0.45f;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
