using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISliderVolume : MonoBehaviour
{
    [SerializeField] private AudioDataSo audioData;
    [SerializeField] private AudioChannel channel;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text percentText;

    private void Start()
    {
        slider.value = audioData.GetVolume(channel);
        UpdateText(slider.value);
    }

    private void OnEnable()
    {
        slider.onValueChanged.AddListener(HandleValueChanged);
    }
    private void OnDisable()
    {
        slider.onValueChanged.RemoveListener(HandleValueChanged);
    }

    private void HandleValueChanged(float value)
    {
        audioData.SetVolumeOf(channel, value);
        UpdateText(value);
    }

    private void UpdateText(float value)
    {
        percentText.text = Mathf.RoundToInt(value * 100) + "%";
    }
}
