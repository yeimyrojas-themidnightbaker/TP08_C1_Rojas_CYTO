using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    [SerializeField] private SaveDataSo saveData;
    [SerializeField] private Image iconImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private Button btnBuy;

    private ShopItemSo shopItem;
    private void OnEnable()
    {
        btnBuy.onClick.AddListener(OnBtnBuyClicked);
        saveData.OnUpgradePurchased += Refresh;
    }

    private void OnDisable()
    {
        btnBuy.onClick.RemoveListener(OnBtnBuyClicked);
        saveData.OnUpgradePurchased -= Refresh;
    }

    public void SetUp(ShopItemSo newItem)
    {
        shopItem = newItem;
        iconImage.sprite = shopItem.SpriteUpgrade;
        nameText.text = shopItem.LabelName;
        descriptionText.text = shopItem.Description;
        costText.text = shopItem.Cost.ToString();

        Refresh();
    }
    private void Refresh()
    {
        bool isOwned = saveData.HasUpgrade(shopItem.UpgradeType);
        bool canAfford = saveData.TotalAminoacids >= shopItem.Cost;
        if(!isOwned && canAfford)
        {
            btnBuy.interactable = true;
        }
        else
        {
            btnBuy.interactable = false;
        }

    }
    private void OnBtnBuyClicked()
    {
        saveData.TryBuy(shopItem);
    }
}
