using TMPro;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    [SerializeField] private SaveDataSo saveData;
    [SerializeField] private TMP_Text currentAminoacids;
    [SerializeField] private ShopItemSo[] shopItems;
    [SerializeField] private UIShopItem cardPrefab;
    [SerializeField] private Transform cardContainer;



    private void Start()
    {
        saveData.Load();
        RefreshAminoacids();

        foreach(var shopItem in shopItems)
        {
            UIShopItem card = Instantiate(cardPrefab, cardContainer);
            card.SetUp(shopItem);
        }
    }

    private void OnEnable()
    {
     
        saveData.OnUpgradePurchased += RefreshAminoacids;
    }

    private void OnDisable()
    {
        saveData.OnUpgradePurchased -= RefreshAminoacids;
    }

    private void RefreshAminoacids()
    {
        currentAminoacids.text = saveData.TotalAminoacids.ToString();
    }
}
