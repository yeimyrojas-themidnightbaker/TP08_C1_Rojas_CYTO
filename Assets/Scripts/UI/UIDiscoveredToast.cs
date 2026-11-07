using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDiscoveredToast : MonoBehaviour
{
    private const string TitlePrefix = "New Atlas entry: ";
    [SerializeField] private SaveDataSo saveData;
    [SerializeField] private GameObject toastPanel;

    [SerializeField] private Image toastIcon;
    [SerializeField] private TMP_Text toastTitle;
    [SerializeField] private TMP_Text toastHint;
    [SerializeField] private float showDuration = 4f;

    private Coroutine currentToast;
    private AtlasEntrySo currentEntry;

    private void Start()
    {
        toastPanel.SetActive(false);
    }

    private void OnEnable()
    {
        saveData.OnEntryDiscovered += HandleShowDiscoveredToast;
    }
    private void OnDisable()
    {
        saveData.OnEntryDiscovered -= HandleShowDiscoveredToast;
    }

    private void HandleShowDiscoveredToast(AtlasEntrySo entry)
    {
        if (currentToast != null)
        {
            StopCoroutine(currentToast);
        }    
            currentToast = StartCoroutine(ShowToast(entry));

    }

    private IEnumerator ShowToast(AtlasEntrySo entry)
    {
        toastPanel.SetActive(true);
        toastIcon.sprite = entry.EntryIcon;
        toastTitle.text = TitlePrefix + entry.DisplayName;
        toastHint.text = entry.GameHint;

        yield return new WaitForSeconds(showDuration);
        toastPanel.SetActive(false);
        currentToast = null;
    }

}
