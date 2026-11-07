using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAtlasEntry : MonoBehaviour
{
    [SerializeField] private SaveDataSo saveData;
    [SerializeField] private Image entryIcon;
    [SerializeField] private TMP_Text entryLabel;
    [SerializeField] private Button btnShow;
    [SerializeField] private Color lockedColor = Color.black;

    private AtlasEntrySo atlasEntry;
    private UIAtlas atlas;

    private const string LockedLabel = "???";

    private void OnEnable()
    {
        btnShow.onClick.AddListener(OnBtnShowClicked);
    }

    private void OnDisable()
    {
        btnShow.onClick.RemoveListener(OnBtnShowClicked);
    }
    public void SetUp(AtlasEntrySo entry, UIAtlas owner)
    {
        atlasEntry = entry;
        atlas = owner;
        entryIcon.sprite = atlasEntry.EntryIcon;
        if(saveData.HasDiscovered(atlasEntry.EntryType))
        {
            entryIcon.color = Color.white;
            entryLabel.text = atlasEntry.DisplayName;
            btnShow.interactable = true;
        }
        else
        {
            entryIcon.color = lockedColor;
            entryLabel.text = LockedLabel;
            btnShow.interactable = false;
        }
    }

    private void OnBtnShowClicked()
    {
        atlas.ShowDetail(atlasEntry);
    }
}
