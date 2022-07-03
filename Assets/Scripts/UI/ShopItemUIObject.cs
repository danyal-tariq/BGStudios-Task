using ScriptableEvents.Events;
using Spine;
using Spine.Unity;
using Spine.Unity.Examples;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUIObject : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private SkeletonGraphic itemIcon;
    [SerializeField] private CombinedSkin skinCombinerUtility;
    [SerializeField] private TextMeshProUGUI itemPrice;
    [SerializeField] private Button buyOrEquip;
    [SerializeField] private Button tryItem;
    [SerializeField] private TextMeshProUGUI buttonText;

    [Header("Events")]
    public SkinDataScriptableEvent skinDataEvent;

    public void Setdata(string skin , int price)
    {
        skinCombinerUtility.SetSkin(new List<string> { skin });
        itemPrice.SetText(price.ToString());
        tryItem.onClick.AddListener(() =>
        {
            TryItem(new List<string> { skin });
        });
    }
    public void TryItem(List<string> skin)
    {
        SkinData skinData =new SkinData();
        skinData.skinsToCombine = skin;

        skinDataEvent.Raise(skinData);
    }
    public void BuyItem()
    {

    }

}
