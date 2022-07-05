using System.Collections.Generic;
using _Scripts.ScriptableEvents.Events;
using _Scripts.Spine;
using ScriptableEvents.Events;
using Spine.Unity;
using Spine.Unity.Examples;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace _Scripts.UI
{
    public class ShopItemUIObject : MonoBehaviour
    {
        [SerializeField] private int id;
        [SerializeField] private ItemType itemType;
        [SerializeField] private SkeletonGraphic itemIcon;
        [SerializeField] private CombinedSkin skinCombinerUtility;
        [SerializeField] private TextMeshProUGUI itemPrice;
        [SerializeField] private Button buyOrEquip;
        [SerializeField] private Button tryItem;
        [SerializeField] private TextMeshProUGUI buttonText;

        [Header("Events")] public SkinDataScriptableEvent skinDataEvent;
        public SkinDataScriptableEvent skinEquipEvent;
        public ShopItemDataScriptableEvent buyEvent;

        public void SetData(int itemId, ItemType type, string skin, int price, bool bought)
        {
            this.id = itemId;
            itemType = type;
            skinCombinerUtility.SetSkin(new List<string> { skin });
            itemPrice.SetText(price.ToString());

            tryItem.onClick.RemoveAllListeners();
            buyOrEquip.onClick.RemoveAllListeners();

            tryItem.onClick.AddListener(() => { TryItem(new List<string> { skin }); });
            if (bought)
            {
                tryItem.gameObject.SetActive(false);
                buttonText.SetText("Equip");
                itemPrice.SetText("Owned");
                buyOrEquip.onClick.AddListener((() => { EquipItem(new List<string> { skin }); }));
            }
            else
            {
                buyOrEquip.onClick.AddListener(BuyItem);
            }
        }

        private void TryItem(List<string> skin)
        {
            var skinData = new SkinData
            {
                skinsToCombine = skin
            };

            skinDataEvent.Raise(skinData);
        }

        private void EquipItem(List<string> skin)
        {
            var skinData = new SkinData
            {
                skinsToCombine = skin
            };

            skinEquipEvent.Raise(skinData);
            skinDataEvent.Raise(skinData);
        }

        private void BuyItem()
        {
            buyEvent.Raise(new ShopItemData { id = id, type = itemType });
        }
    }
}