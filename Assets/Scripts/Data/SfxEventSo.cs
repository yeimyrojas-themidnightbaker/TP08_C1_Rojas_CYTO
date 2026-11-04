using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "SfxEvent", menuName = "Data/SfxEvent")]
public class SfxEventSo : ScriptableObject
{
    public event UnityAction<AudioClip> OnPlayRequested;
    public void Play (AudioClip clip)
    {
        OnPlayRequested?.Invoke(clip);
    }
}
