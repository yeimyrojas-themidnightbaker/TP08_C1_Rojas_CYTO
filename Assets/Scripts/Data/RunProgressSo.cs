using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "RunProgressData", menuName = "Data/RunProgressData")]
public class RunProgressSo : ScriptableObject
{
    private int currentAminoacid;
    public int CurrentAminoacid => currentAminoacid;

    private bool hasAntigen;
    public bool HasAntigen => hasAntigen;

    private int currentScore;
    public int CurrentScore => currentScore;

    public event UnityAction<int> OnAminoacidChanged;
    public event UnityAction<bool> OnAntigenChanged;
    public event UnityAction<int> OnScoreChanged;
    public void AddAminoacid(int aminoacid)
    {
        currentAminoacid += aminoacid;
        OnAminoacidChanged?.Invoke(CurrentAminoacid);

    }

    public void AddScore(int score)
    {
        currentScore += score;
        OnScoreChanged?.Invoke(CurrentScore);
    }
    public void TakeAntigen()
    {
        hasAntigen = true;
        OnAntigenChanged?.Invoke(HasAntigen);
    }

    public void ResetAminoacid()
    {
        currentAminoacid = 0;
        OnAminoacidChanged?.Invoke(CurrentAminoacid);
    }

    public void ResetScore()
    {
        currentScore = 0;
        OnScoreChanged?.Invoke(CurrentScore);
    }

    public void ResetAntigen()
    {
        hasAntigen = false;
        OnAntigenChanged?.Invoke(HasAntigen);
    }

    public void ResetRun()
    {
        ResetAminoacid();
        ResetScore();
        ResetAntigen();
    }
}
