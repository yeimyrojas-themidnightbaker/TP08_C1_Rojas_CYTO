using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.TryGetComponent<PlayerHealth> (out PlayerHealth playerHealth))
        {
            float direction = Mathf.Sign(other.transform.position.x - transform.position.x);
            playerHealth.TakeHit(direction);
        }
    }
}
