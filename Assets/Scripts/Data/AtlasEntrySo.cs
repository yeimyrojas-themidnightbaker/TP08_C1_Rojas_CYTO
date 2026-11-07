using UnityEngine;
[CreateAssetMenu(fileName = "AtlasEntry", menuName = "Data/AtlasEntry")]
public class AtlasEntrySo : ScriptableObject
{
    [SerializeField] private AtlasEntryType entryType;
    public AtlasEntryType EntryType => entryType;

    [SerializeField] private Sprite entryIcon;
    public Sprite EntryIcon => entryIcon;

    [SerializeField] private string displayName;
    public string DisplayName => displayName;

    [SerializeField, TextArea] private string description;
    public string Description => description;

    [SerializeField] private string gameHint;
    public string GameHint => gameHint;
    
}
