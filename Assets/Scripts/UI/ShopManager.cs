using Spine.Unity.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopInventory inventory;
    [Header("Item Containers")]
    [SerializeField] private Transform torsoSection;
    [SerializeField] private Transform legSection;
    [SerializeField] private Transform accesorySection;

    [Header("Prefabs")]
    public ShopItemUIObject itemPrefab;
    [Header("Character Preview")]
    [SerializeField] private CombinedSkin skin;
    private void Start()
    {
        PopulateShopUI();
    }
    public void PopulateShopUI()
    {
        foreach (var item in inventory.torsoItems)
        {
            var uiItem = Instantiate(itemPrefab,torsoSection);
            uiItem.Setdata(item.spineSkin, item.price);

        }
        foreach (var item in inventory.legItems)
        {
            var uiItem = Instantiate(itemPrefab, legSection);
            uiItem.Setdata(item.spineSkin, item.price);


        }
        foreach (var item in inventory.accesoryItems)
        {
            var uiItem = Instantiate(itemPrefab, accesorySection);
            uiItem.Setdata(item.spineSkin, item.price);

        }
    }
}
