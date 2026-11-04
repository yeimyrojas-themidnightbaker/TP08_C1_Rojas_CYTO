using UnityEngine;
using UnityEngine.Audio;
[CreateAssetMenu(fileName = "AudioData", menuName = "Data/AudioData")]
public class AudioDataSo : ScriptableObject
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private float defaultVolume = 0.8f;
    [SerializeField] private AudioClip victoryClip;
    public AudioClip VictoryClip => victoryClip;
    [SerializeField] private AudioClip defeatClip;
    public AudioClip DefeatClip => defeatClip;

    private string KeyOf(AudioChannel channel)
    {
        return channel.ToString() + "Volume";
    }

    public float GetVolume(AudioChannel channel)
    {
        return PlayerPrefs.GetFloat(KeyOf(channel), defaultVolume);
    }
    public void SetVolumeOf(AudioChannel channel, float value)
    {
        PlayerPrefs.SetFloat(KeyOf(channel), value);
        mixer.SetFloat(KeyOf(channel), Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f);
    }
    public void ApplyAll()
    {
        foreach (AudioChannel channel in System.Enum.GetValues(typeof(AudioChannel)))
        {
            SetVolumeOf(channel, GetVolume(channel));
        }
        PlayerPrefs.Save();
    }

}
