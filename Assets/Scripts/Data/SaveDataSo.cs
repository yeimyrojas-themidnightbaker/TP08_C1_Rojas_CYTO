using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "SaveData", menuName = "Data/SaveData")]
public class SaveDataSo : ScriptableObject
{
    private const string BestScoreKey = "BestScore";
    private const string BestTimeKey = "BestTime";
    private const string TotalAminoacidsKey = "TotalAminoacids";
    private const string UpgradeKeySuffix = "Upgrade";

    private int bestScore;
    public int BestScore => bestScore;
    private float bestTime;
    public float BestTime => bestTime;
    private int totalAminoacids;
    public int TotalAminoacids => totalAminoacids;
    private bool isNewRecord;
    public bool IsNewRecord => isNewRecord;

    public event UnityAction OnUpgradePurchased;

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
        if (score > bestScore)
        {
            bestScore = score;
            isNewRecord = true;
        }

        if (iswon && (bestTime == 0 || time < bestTime))
        {
            bestTime = time;
        }
        Save();
    }
    private string KeyOf(UpgradeType upgrade)
    {
        return upgrade.ToString() + UpgradeKeySuffix;
    }
    public bool HasUpgrade(UpgradeType upgrade)
    {
        int savedValue = PlayerPrefs.GetInt(KeyOf(upgrade), 0);
        {
            if (savedValue == 1)
                return true;
            else
                return false;
        }
    }

    public bool TryBuy(ShopItemSo item)
    {
        if(HasUpgrade(item.UpgradeType))
        {
            return false;
        }
        if(totalAminoacids < item.Cost)
        {
            return false;
        }
        totalAminoacids -= item.Cost;
        PlayerPrefs.SetInt(KeyOf(item.UpgradeType),1);
        Save();
        OnUpgradePurchased?.Invoke();
        return true;
    }

}
