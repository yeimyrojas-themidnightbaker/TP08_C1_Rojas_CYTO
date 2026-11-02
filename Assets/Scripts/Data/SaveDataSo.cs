using UnityEngine;
[CreateAssetMenu(fileName = "SaveData", menuName = "Data/SaveData")]
public class SaveDataSo : ScriptableObject
{
    private const string BestScoreKey = "BestScore";
    private const string BestTimeKey = "BestTime";
    private const string TotalAminoacidsKey = "TotalAminoacids";

    private int bestScore;
    public int BestScore => bestScore;
    private float bestTime;
    public float BestTime => bestTime;
    private int totalAminoacids;
    public int TotalAminoacids => totalAminoacids;
    private bool isNewRecord;
    public bool IsNewRecord => isNewRecord;

    public void Load()
    {
        bestScore = PlayerPrefs.GetInt(BestScoreKey, 0);
        bestTime = PlayerPrefs.GetFloat(BestTimeKey, 0);
        totalAminoacids = PlayerPrefs.GetInt(TotalAminoacidsKey, 0);

    }
    public void Save()
    {
        PlayerPrefs.SetInt(BestScoreKey, bestScore);
        PlayerPrefs.SetFloat(BestTimeKey, bestTime);
        PlayerPrefs.SetInt(TotalAminoacidsKey, totalAminoacids);
        PlayerPrefs.Save();
    }
    public void CommitRun(int score, int aminoacid, float time, bool iswon)
    {
        isNewRecord = false;
        totalAminoacids += aminoacid;
        if(score > bestScore)
        {
            bestScore = score;
            isNewRecord = true;
        }

        if(iswon && (bestTime == 0 || time < bestTime))
        {
            bestTime = time;
        }
        Save();
    }
}
