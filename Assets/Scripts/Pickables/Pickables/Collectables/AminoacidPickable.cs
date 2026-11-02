using UnityEngine;

public class AminoacidPickable : Pickable
{
    [SerializeField] private RunProgressSo runProgressData;
    protected override void ApplyEffect(Collider2D other)
    {
        runProgressData.AddAminoacid(pickableData.Amount);
    }
}
