using TMPro;
using UnityEngine;

public class UIShop : MonoBehaviour
{
    [SerializeField] private SaveDataSo saveData;
    [SerializeField] private TMP_Text currentAminoacids;
    [SerializeField] private ShopItemSo[] shopItems;
    [SerializeField] private UIShopItem cardPrefab;
    [SerializeField] private Transform cardContainer;
    [SerializeField] private AudioSource uiAudioSource;
    [SerializeField] private AudioClip buyClip;



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
        saveData.OnUpgradePurchased += HandleUpgradePurchased;
    }

    private void OnDisable()
    {
        saveData.OnUpgradePurchased -= RefreshAminoacids;
        saveData.OnUpgradePurchased -= HandleUpgradePurchased;
    }

    private void RefreshAminoacids()
    {
        currentAminoacids.text = saveData.TotalAminoacids.ToString();
    }

    private void HandleUpgradePurchased()
    {
        uiAudioSource.PlayOneShot(buyClip);
    }
}
