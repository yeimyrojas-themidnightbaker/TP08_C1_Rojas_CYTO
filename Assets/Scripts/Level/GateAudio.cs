using UnityEngine;

public class GateAudio : MonoBehaviour
{
    [SerializeField] private AntigenGate antigenGate;
    [SerializeField] private LevelDataSo levelData;
    // Suggestion: saveData no se usa en esta clase, sacalo.
    [SerializeField] private SaveDataSo saveData;
    [SerializeField] private SfxEventSo sfxEvent;

    private void OnEnable()
    {
        antigenGate.OnGateOpened += HandleGateAudio;
    }

    private void OnDisable()
    {
        antigenGate.OnGateOpened -= HandleGateAudio;
    }

    private void HandleGateAudio()
    {
        sfxEvent.Play(levelData.ClipGate);
    }
}
