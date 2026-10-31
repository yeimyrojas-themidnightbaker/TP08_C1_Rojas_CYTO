using TMPro;
using UnityEngine;

public class UIAminoacids : MonoBehaviour
{
    [SerializeField] private RunProgressSo runProgressData;
    [SerializeField] private TMP_Text aminoacidText;

    private void Start()
    {
        runProgressData.ResetRun();
        //mover al GameManager despues
    }
    private void OnEnable()
    {
        runProgressData.OnAminoacidChanged += HandleAminoacidHUD;
    }
    private void OnDisable()
    {
        runProgressData.OnAminoacidChanged -= HandleAminoacidHUD;
    }

    private void HandleAminoacidHUD(int aminoacidCounter)
    {
        aminoacidText.text = " x " + aminoacidCounter.ToString();
    }
}
