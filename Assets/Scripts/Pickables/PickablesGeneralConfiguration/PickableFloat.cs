using UnityEngine;

public class PickableFloat : MonoBehaviour
{
    [SerializeField] private PickableDataSo pickableData;
    private Vector3 startPosition;
    private float phase;

    private void Start()
    {
        startPosition = transform.position;
        phase = Random.Range(0f, (Mathf.PI * 2f));
    }

    private void Update()
    {
        float offsetY = Mathf.Sin(Time.time * pickableData.FloatSpeed + phase) * pickableData.FloatAmplitude;
        transform.position = startPosition + new Vector3 (0f, offsetY, 0f);
    }
}
