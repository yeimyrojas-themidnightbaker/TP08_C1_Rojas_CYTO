using UnityEngine;

public class AntigenPickup : Pickable
{
    [SerializeField] private RunProgressSo runProgressData;
    protected override void ApplyEffect(Collider2D other)
    {
        runProgressData.TakeAntigen();
    }
}
