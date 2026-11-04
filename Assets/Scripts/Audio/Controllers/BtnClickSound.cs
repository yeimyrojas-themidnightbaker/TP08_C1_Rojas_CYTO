using UnityEngine;
using UnityEngine.UI;

public class BtnClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource uiAudioSource;
    [SerializeField] private AudioClip uiAudioClip;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    
    private void OnEnable()
    {
        button.onClick.AddListener(HandleUiAudio); 
    }

    private void OnDisable()
    {
        button.onClick.RemoveListener(HandleUiAudio);
    }

    private void HandleUiAudio()
    {
        uiAudioSource.PlayOneShot(uiAudioClip);
    }
}
