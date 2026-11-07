using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIAtlas : MonoBehaviour
{
    private const string EmptyDetailText = "Select a discovered entry.";
    [SerializeField] private AtlasEntrySo[] atlasEntries;
    [SerializeField] private UIAtlasEntry cardPrefab;
    [SerializeField] private Transform cardContainer;

    [Header("Detail")]
    [SerializeField] private TMP_Text detailName;
    [SerializeField] private TMP_Text detailDescription;
    [SerializeField] private Image detailImage;

    private void Start()
    {
        foreach (AtlasEntrySo entry in atlasEntries)
        {
            UIAtlasEntry card = Instantiate(cardPrefab, cardContainer);
            card.SetUp(entry, this);
            detailName.text = "";
            detailDescription.text = EmptyDetailText;
            detailImage.enabled = false;
        }
    }

    public void ShowDetail(AtlasEntrySo entry)
    {
        detailImage.sprite = entry.EntryIcon;
        detailImage.enabled = true;
        detailName.text = entry.DisplayName;
        detailDescription.text = entry.Description;
        detailImage.sprite = entry.EntryIcon;
    }
}
