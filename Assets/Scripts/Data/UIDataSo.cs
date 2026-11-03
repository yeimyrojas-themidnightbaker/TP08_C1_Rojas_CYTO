using UnityEngine;
[CreateAssetMenu(fileName = "UIData", menuName = "Data/UIData")]
public class UIDataSo : ScriptableObject
{
    [SerializeField] private float panelFadeDuration = 0.3f;
    public float PanelFadeDuration => panelFadeDuration;
}

