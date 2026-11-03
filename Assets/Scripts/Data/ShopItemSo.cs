using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemData", menuName = "Data/ShopItemData")]
public class ShopItemSo : ScriptableObject
{
    [SerializeField] private UpgradeType upgradeType;
    public UpgradeType UpgradeType => upgradeType;

    [SerializeField] private int upgradeValue;
    public int UpgradeValue => upgradeValue;

    [SerializeField] private int cost;
    public int Cost => cost;


    [SerializeField] private Sprite spriteUpgrade;
    public Sprite SpriteUpgrade => spriteUpgrade;

    [SerializeField, TextArea] private string description;
    public string Description => description;

    [SerializeField] private string labelName;
    public string LabelName => labelName;

}
