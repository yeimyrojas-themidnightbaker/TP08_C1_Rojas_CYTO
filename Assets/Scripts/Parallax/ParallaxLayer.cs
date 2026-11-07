using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private ParallaxLayerSo layerData;
    [SerializeField] private Transform cameraTransform;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 cameraOffset = cameraTransform.position - startPosition;

        float newX = startPosition.x + cameraOffset.x * layerData.Factor.x;
        float newY = startPosition.y + cameraOffset.y * layerData.Factor.y;

        transform.position = new Vector3(newX, newY, startPosition.z);
    }
}
