using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "SaveData", menuName = "Data/SaveData")]
public class SaveDataSo : ScriptableObject
{
    private const string BestScoreKey = "BestScore";
    private const string BestTimeKey = "BestTime";
    private const string TotalAminoacidsKey = "TotalAminoacids";
    private const string UpgradeKeySuffix = "Upgrade";
    private const string DiscoveredKeySuffix = "Discovered";

    //score
    private int bestScore;
    public int BestScore => bestScore;
    private float bestTime;
    public float BestTime => bestTime;
    private int totalAminoacids;
    public int TotalAminoacids => totalAminoacids;
    private bool isNewRecord;
    public bool IsNewRecord => isNewRecord;

    public event UnityAction OnUpgradePurchased;
    public event UnityAction<AtlasEntrySo> OnEntryDiscovered;

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

    //shop
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
        if (HasUpgrade(item.UpgradeType))
            return false;

        if (totalAminoacids < item.Cost)
            return false;

        totalAminoacids -= item.Cost;
        PlayerPrefs.SetInt(KeyOf(item.UpgradeType), 1);
        Save();
        OnUpgradePurchased?.Invoke();
        return true;
    }

    //atlas
    private string KeyOfDiscovered(AtlasEntryType entry)
    {
        return entry.ToString() + DiscoveredKeySuffix;
    }

    public bool HasDiscovered(AtlasEntryType entry)
    {
        int savedValue = PlayerPrefs.GetInt(KeyOfDiscovered(entry), 0);
        {
            if (savedValue == 1)
                return true;
            else
                return false;
        }
    }

    public bool MarkDiscovered(AtlasEntrySo entry)
    {
        if (HasDiscovered(entry.EntryType))
        {
            return false;
        }
        PlayerPrefs.SetInt(KeyOfDiscovered(entry.EntryType), 1);
        Save();
        OnEntryDiscovered?.Invoke(entry);
        return true;
    }


}
