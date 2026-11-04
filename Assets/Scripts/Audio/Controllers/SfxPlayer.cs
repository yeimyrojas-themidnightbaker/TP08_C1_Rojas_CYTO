using UnityEngine;

public class SfxPlayer : MonoBehaviour
{
    [SerializeField] private SfxEventSo sfxEvent;
    [SerializeField] private AudioSource fxSource;
    private void OnEnable()
    {
        sfxEvent.OnPlayRequested += HandlePlaySfx;
    }

    private void OnDisable()
    {
        sfxEvent.OnPlayRequested -= HandlePlaySfx;
    }

    private void HandlePlaySfx(AudioClip clip)
    {
        fxSource.PlayOneShot(clip);
    }
}
