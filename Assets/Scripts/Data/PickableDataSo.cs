using UnityEngine;
[CreateAssetMenu(fileName = "PickableData", menuName = "Data/PickableData")]
public class PickableDataSo : ScriptableObject
{
    [SerializeField] private int amount = 1;
    public int Amount => amount;

    [SerializeField] private GameObject pickupParticles;
    public GameObject PickupParticles => pickupParticles;
    [SerializeField] private AudioClip pickupClip;
    public AudioClip PickupClip => pickupClip;

    [Header("Float")]
    [SerializeField] private float floatAmplitude = 0.5f;
    public float FloatAmplitude => floatAmplitude;
    [SerializeField] private float floatSpeed = 2f;
    public float FloatSpeed => floatSpeed;

    [Header("Powerup")]
    [SerializeField] private PowerUpType powerUpType;
    public PowerUpType PowerUpType => powerUpType;
    [SerializeField] private float powerUpDuration = 15f;
    public float PowerUpDuration => powerUpDuration;

    [Header("AtlasEntry")]
    [SerializeField] private AtlasEntrySo atlasEntry;
    public AtlasEntrySo AtlasEntry => atlasEntry;
}
