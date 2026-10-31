using UnityEngine;

public class UIAntigenIcon : MonoBehaviour
{
    [SerializeField] private RunProgressSo runProgressData;
    [SerializeField] private GameObject antigenIcon;

    private void OnEnable()
    {
        runProgressData.OnAntigenChanged += HandleAntigenIcon;
    }
    private void OnDisable()
    {
        runProgressData.OnAntigenChanged -= HandleAntigenIcon;
    }
    private void HandleAntigenIcon (bool isActive)
    {
        antigenIcon.SetActive (isActive);
    }
}
