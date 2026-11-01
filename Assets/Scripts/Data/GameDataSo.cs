using UnityEngine;
[CreateAssetMenu(fileName = "GameData", menuName = "Data / GameData")]

public class GameDataSo : ScriptableObject
{
    [SerializeField] private float endDelay = 2f;
    public float EndDelay => endDelay;
    [SerializeField] private KeyCode[] pauseKeys = { KeyCode.Escape };
    public KeyCode[] PauseKeys => pauseKeys;

}
