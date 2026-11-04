using UnityEngine;

public class ResultsSoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private GameResultsSo gameResults;
    [SerializeField] private AudioDataSo audioData;

    private void Start()
    {
        if(gameResults.Won)
        {
            musicSource.PlayOneShot(audioData.VictoryClip);
        }
        else
        {
            musicSource.PlayOneShot(audioData.DefeatClip);
        }
    }
}
