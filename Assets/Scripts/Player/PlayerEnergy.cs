using UnityEngine;
using UnityEngine.Events;

public class PlayerEnergy : MonoBehaviour
{
    [SerializeField] private PlayerDataSo playerData;
    private float currentAtp;
    public float CurrentAtp => currentAtp;
    public float MaxAtp => playerData.MaxAtp;
    public event UnityAction<float, float> OnAtpChanged;

    private void Start()
    {
        currentAtp = 0;
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
