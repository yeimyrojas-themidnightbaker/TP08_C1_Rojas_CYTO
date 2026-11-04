using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    [SerializeField] private ShopItemSo startEnergyUpgrade;
    [SerializeField] private SaveDataSo saveData;
    private float currentAtp;
    public float CurrentAtp => currentAtp;
    private float maxAtp;
    public float MaxAtp => maxAtp;

    public event UnityAction<float, float> OnAtpChanged;

    private void Start()
    {
        maxAtp = playerData.MaxAtp;
        currentAtp = 0;
        if(saveData.HasUpgrade(startEnergyUpgrade.UpgradeType))
        {
            currentAtp = startEnergyUpgrade.UpgradeValue;
        }
        OnAtpChanged?.Invoke(CurrentAtp, MaxAtp);
    }
    
    public void AddAtp(float amount)
    {
        currentAtp = Mathf.Min(currentAtp + amount, MaxAtp);
        OnAtpChanged?.Invoke(CurrentAtp, MaxAtp);
    }

    public bool CanAfford (float amount)
    {
        if (currentAtp >= amount)
            return true;
        return false;
    }    

    public bool TrySpend (float amount)
    {
        if (!CanAfford(amount))
            return false;
        currentAtp -= amount;
        OnAtpChanged?.Invoke(CurrentAtp, MaxAtp);
        return true;
    }
}
