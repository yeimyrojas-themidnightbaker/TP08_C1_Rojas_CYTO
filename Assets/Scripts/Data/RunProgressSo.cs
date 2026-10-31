using UnityEngine;
using UnityEngine.Events;
[CreateAssetMenu(fileName = "RunProgressData", menuName = "Data/RunProgressData")]
public class RunProgressSo : ScriptableObject
{
    private int currentAminoacid;
    public int CurrentAminoacid => currentAminoacid;
    private bool hasAntigen;
    public bool HasAntigen => hasAntigen;

    public event UnityAction<int> OnAminoacidChanged;
    public event UnityAction<bool> OnAntigenChanged;
    public void AddAminoacid(int aminoacid)
    {
        currentAminoacid += aminoacid;
        OnAminoacidChanged?.Invoke(CurrentAminoacid);

    }

    public void ResetAminoacid()
    {
        currentAminoacid = 0;
        OnAminoacidChanged?.Invoke(CurrentAminoacid);
    }

    public void TakeAntigen()
    {
        hasAntigen = true;
        OnAntigenChanged?.Invoke(HasAntigen);
    }

    public void ResetAntigen()
    {
        hasAntigen = false;
        OnAntigenChanged?.Invoke(HasAntigen);
    }

    public void ResetRun()
    {
        ResetAminoacid();
        ResetAntigen();
    }

    //M15 mover al GameManager
}
