using System;
using Spine.Unity.Examples;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scriptable_Objects;
using ScriptableEvents.Events;
using UnityEngine;
using UnityEngine.Serialization;
using Utility;

public class ShopManager : MonoBehaviour
{
    public ShopInventory inventory;
    [Header("Persistant Data")]
    [SerializeField] private PersistantData data;
    [Header("Item Containers")]
    [SerializeField] private Transform torsoSection;
    [SerializeField] private Transform legSection;
    [SerializeField] private Transform accessorySection;
    [Header("Item References")]
    [SerializeField] private List<ShopItemUIObject> torsoItems;
    [SerializeField] private List<ShopItemUIObject> legItems;
    [SerializeField] private List<ShopItemUIObject> accessoryItems;

    [Header("Prefabs")]
    public ShopItemUIObject itemPrefab;
    [Header("Character Preview")]
    [SerializeField] private CombinedSkin skin;
    [Header("Events")] 
    [SerializeField] private SimpleScriptableEvent updateCashEvent;

    private void Awake()
    {
        inventory.LoadData();
        
        torsoItems = new List<ShopItemUIObject>();
        legItems = new List<ShopItemUIObject>();
        accessoryItems = new List<ShopItemUIObject>();
    }

    private void Start()
    {
        PopulateShopUI();
    }

    private void PopulateShopUI()
    {
        foreach (var item in inventory.torsoItems)
        {
            var uiItem = Instantiate(itemPrefab,torsoSection);
            uiItem.SetData(item.id,ItemType.Torso,item.spineSkin, item.price,item.isBought);
            torsoItems.Add(uiItem);

        }
        foreach (var item in inventory.legItems)
        {
            var uiItem = Instantiate(itemPrefab, legSection);
            uiItem.SetData(item.id,ItemType.Legs,item.spineSkin, item.price,item.isBought);
            legItems.Add(uiItem);


        }
        foreach (var item in inventory.accessoryItems)
        {
            var uiItem = Instantiate(itemPrefab, accessorySection);
            uiItem.SetData(item.id,ItemType.Accessory,item.spineSkin, item.price,item.isBought);
            accessoryItems.Add(uiItem);

        }
    }

    private void UpdateUI()
    {
        for (var index = 0; index < torsoItems.Count; index++)
        {
            var uiItem = torsoItems[index];
            var item = inventory.torsoItems[index];
            uiItem.SetData(item.id, ItemType.Torso, item.spineSkin, item.price, item.isBought);
        }
        for (var index = 0; index < legItems.Count; index++)
        {
            var uiItem = legItems[index];
            var item = inventory.legItems[index];
            uiItem.SetData(item.id, ItemType.Legs, item.spineSkin, item.price, item.isBought);
        }
        for (var index = 0; index < accessoryItems.Count; index++)
        {
            var uiItem = accessoryItems[index];
            var item = inventory.accessoryItems[index];
            uiItem.SetData(item.id, ItemType.Accessory, item.spineSkin, item.price, item.isBought);
        }
    }

    public void BuyItem(ShopItemData itemData)
    {
        int cash = 0;
        int id = itemData.id;
        ShopItem item = new ShopItem();
        switch (itemData.type)
        {
            case ItemType.Torso:
            {
                item = inventory.torsoItems.FirstOrDefault(x => x.id == id);
                if (item != null) cash = item.price;
                break;
            }
            case ItemType.Legs:
            {
                item = inventory.legItems.FirstOrDefault(x => x.id == id);
                if (item != null) cash = item.price;
                break;
            }
            case ItemType.Accessory:
            {
                item = inventory.accessoryItems.FirstOrDefault(x => x.id == id);
                if (item != null) cash = item.price;
                break;
            }
            case ItemType.Head:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (data.cash > cash)
        {
            data.DeductCash(cash);
            if (item != null) item.isBought = true;
            inventory.SaveData();
            UpdateUI();
            updateCashEvent.Raise();
        }
      
    }
}
