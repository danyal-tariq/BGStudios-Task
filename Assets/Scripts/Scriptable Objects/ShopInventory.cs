using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopInventorySO",menuName ="ScriptableObjects/ShopInventory")]
public class ShopInventory : ScriptableObject
{
    public List<ShopItem> items;
    public SkeletonDataAsset skeletonData;
}
[Serializable]
public class ShopItem
{
    public string name;
    public Sprite itemSprite;
    public int price;
    public bool isBought;
    [SpineSkin(dataField ="skeletonData")] public string spineSkin;
}
