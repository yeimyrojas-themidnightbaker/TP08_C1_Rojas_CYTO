using UnityEngine;
[CreateAssetMenu (fileName = "LevelData", menuName = "Data/LevelData")]
public class LevelDataSo : ScriptableObject
{
    [SerializeField] private float referenceTime = 900f;
    public float ReferenceTime => referenceTime;
    [SerializeField] private int pointsPerSecond = 5;
    public float PointsPerSecond => pointsPerSecond;
    [SerializeField] private int pointsPerCapsule = 500;
    public float PointsPerCapsule => pointsPerCapsule;
    [SerializeField] private AudioClip clipGate;
    public AudioClip ClipGate => clipGate;
}
