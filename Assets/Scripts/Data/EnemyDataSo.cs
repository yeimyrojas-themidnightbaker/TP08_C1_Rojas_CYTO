using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Data/EnemyData")]
public class EnemyDataSo : ScriptableObject
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 5;
    public int MaxHealth => maxHealth;

    [SerializeField] private GameObject deathVfx;
    public GameObject DeathVfx => deathVfx;

    [Header("Rewards")]

    [SerializeField] private int score = 100;
    public int Score => score;

    [SerializeField] private int lootMin = 1;
    public int LootMin => lootMin;

    [SerializeField] private int lootMax = 3;
    public int LootMax => lootMax;

    [SerializeField] private Pickable lootPrefab;
    public Pickable LootPrefab => lootPrefab;

    [SerializeField] private float lootSpread = 1.5f;
    public float LootSpread => lootSpread;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 1.0f;
    public float MoveSpeed => moveSpeed;

    [Header("Toxic Cocci")]
    [SerializeField] private float dangerRange = 6f;
    public float DangerRange => dangerRange;

    [SerializeField] private float inflateSize = 1.3f;
    public float InflateSize => inflateSize;

    [SerializeField] private float windUpTime = 0.4f;
    public float WindUpTime => windUpTime;

    [SerializeField] private float timeBetweenShoots = 2f;
    public float TimeBetweenShoots => timeBetweenShoots;

    [Header("Cluster Patrol")]

    [SerializeField] private GameObject smallCluster;
    public GameObject SmallCluster => smallCluster;

    [SerializeField] private float splitTime = 8f;
    public float SplitTime => splitTime;

    [SerializeField] private float warningTime = 0.4f;
    public float WarningTime => warningTime;

    [SerializeField] private float splitOffsetX = 2.5f;
    public float SplitOffsetX => splitOffsetX;

    [SerializeField] private float splitOffsetY = 0f;
    public float SplitOffsetY => splitOffsetY;

    [Header("Audio")]
    [SerializeField] private AudioClip hitClip;
    public AudioClip HitClip => hitClip;
    [SerializeField] private AudioClip deathClip;
    public AudioClip DeathClip => deathClip;
    [SerializeField] private AudioClip specialClip;
    public AudioClip SpecialClip => specialClip;

    [Header("VisualFeedback")]
    [SerializeField] private Color hitFlashColor;
    public Color HitFlashColor => hitFlashColor;
    [SerializeField] private float hitFlashDuration = 0.1f;
    public float HitFlashDuration => hitFlashDuration;

}
