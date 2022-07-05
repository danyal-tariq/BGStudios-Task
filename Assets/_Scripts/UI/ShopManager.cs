using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Spine;
using Scriptable_Objects;
using ScriptableEvents.Events;
using Spine.Unity.Examples;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace _Scripts.UI
{
    public class ShopManager : MonoBehaviour
    {
        public ShopInventory inventory;

        [Header("Persistant Data")] [SerializeField]
        private PersistantData data;

        [Header("Item Containers")] [SerializeField]
        private Transform torsoSection;

        [SerializeField] private Transform legSection;
        [SerializeField] private Transform accessorySection;
        [Header("Item Tabs")] [SerializeField] private Button torsoTab;
        [SerializeField] private Button legTab;
        [SerializeField] private Button accessoryTab;
        [SerializeField] private Color selectedColor;
        [SerializeField] private Color defaultColor;

        [Header("Item References")] [SerializeField]
        private List<ShopItemUIObject> torsoItems;

        [SerializeField] private List<ShopItemUIObject> legItems;
        [SerializeField] private List<ShopItemUIObject> accessoryItems;

        [Header("Prefabs")] public ShopItemUIObject itemPrefab;

        [Header("Character Preview")] [SerializeField]
        private CombinedSkin skin;

        [Header("Events")] [SerializeField] private SimpleScriptableEvent updateCashEvent;

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

        public void SetTab(int type)
        {
            ItemType tabType = (ItemType)type;

            switch (tabType)
            {
                case ItemType.Torso:
                    torsoSection.gameObject.SetActive(true);
                    legSection.gameObject.SetActive(false);
                    accessorySection.gameObject.SetActive(false);
                    torsoTab.targetGraphic.color = selectedColor;
                    legTab.targetGraphic.color = defaultColor;
                    accessoryTab.targetGraphic.color = defaultColor;
                    break;
                case ItemType.Legs:
                    torsoSection.gameObject.SetActive(false);
                    legSection.gameObject.SetActive(true);
                    accessorySection.gameObject.SetActive(false);
                    torsoTab.targetGraphic.color = defaultColor;
                    legTab.targetGraphic.color = selectedColor;
                    accessoryTab.targetGraphic.color = defaultColor;
                    break;
                case ItemType.Accessory:
                    torsoSection.gameObject.SetActive(false);
                    legSection.gameObject.SetActive(false);
                    accessorySection.gameObject.SetActive(true);
                    torsoTab.targetGraphic.color = defaultColor;
                    legTab.targetGraphic.color = defaultColor;
                    accessoryTab.targetGraphic.color = selectedColor;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(tabType), tabType, null);
            }
        }

        #region Core Update Methods

        private void PopulateShopUI()
        {
            foreach (var item in inventory.torsoItems)
            {
                var uiItem = Instantiate(itemPrefab, torsoSection);
                uiItem.SetData(item.id, ItemType.Torso, item.spineSkin, item.price, item.isBought);
                torsoItems.Add(uiItem);
            }

            foreach (var item in inventory.legItems)
            {
                var uiItem = Instantiate(itemPrefab, legSection);
                uiItem.SetData(item.id, ItemType.Legs, item.spineSkin, item.price, item.isBought);
                legItems.Add(uiItem);
            }

            foreach (var item in inventory.accessoryItems)
            {
                var uiItem = Instantiate(itemPrefab, accessorySection);
                uiItem.SetData(item.id, ItemType.Accessory, item.spineSkin, item.price, item.isBought);
                accessoryItems.Add(uiItem);
            }

            torsoTab.targetGraphic.color = selectedColor;
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
            ShopItem item;
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

        #endregion
    }
}