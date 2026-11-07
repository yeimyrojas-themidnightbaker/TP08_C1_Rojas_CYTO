using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class AntigenGate : MonoBehaviour
{
    [SerializeField] private RunProgressSo runProgressData;
    [SerializeField] private TMP_Text antigenText;
    [SerializeField] private GameObject antigenDoor;
    [SerializeField] private Animator animator;
    [SerializeField] private AtlasEntrySo atlasEntry;
    [SerializeField] private SaveDataSo saveData;
    private bool isPlayerInside;
    private bool isOpened;

    public event UnityAction OnGateOpened;
    private void Start()
    {
        antigenDoor.SetActive(true);
        antigenText.text = "";
    }

    private void OnEnable()
    {
        runProgressData.OnAntigenChanged += HandleAntigenChanged;
    }

    private void OnDisable()
    {
        runProgressData.OnAntigenChanged -= HandleAntigenChanged;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMarker>(out PlayerMarker playerMarker))
        {
            isPlayerInside = true;
            TryOpenGate();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMarker>(out PlayerMarker playerMarker))
        {
            isPlayerInside = false;
            antigenText.text = "";
        }
    }

    private void HandleAntigenChanged(bool hasAntigen)
    {
        TryOpenGate();
    }

    private void TryOpenGate()
    {
        if (isOpened)
            return;
        if (!isPlayerInside)
            return;
        if (!runProgressData.HasAntigen)
        {
            antigenText.text = "Necesitas un antigeno";
            return;
        }
        antigenText.text = "";
        isOpened = true;
        saveData.MarkDiscovered(atlasEntry);
        animator.Play(AnimatorStates.Activation,0,0f);
        antigenDoor.SetActive(false);
        OnGateOpened?.Invoke();
    }
}
