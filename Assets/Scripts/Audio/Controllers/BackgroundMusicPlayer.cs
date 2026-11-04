using UnityEngine;

public class BackgroundMusicPlayer : MonoBehaviour
{
    [SerializeField] private BiofilmBoss biofilmBoss;
    [SerializeField] private AudioClip bossClip;
    [SerializeField] private AudioSource musicAudioSource;
    private void OnEnable()
    {
        biofilmBoss.OnFightStarted += HandleFightStarted;
    }
    private void OnDisable()
    {
        biofilmBoss.OnFightStarted -= HandleFightStarted;
    }

    private void HandleFightStarted()
    {
        musicAudioSource.clip = bossClip;
        musicAudioSource.Play();
    }
}
