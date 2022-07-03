using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopInventorySO",menuName ="ScriptableObjects/ShopInventory")]
public class ShopInventory : ScriptableObject
{
    public List<ShopItem> torsoItems;
    public List<ShopItem> legItems;
    public List<ShopItem> accesoryItems;

    public SkeletonDataAsset skeletonData;
}
[Serializable]
public class ShopItem
{
    public int id;
    public string name;
    public int price;
    public bool isBought;
    [SpineSkin(dataField ="skeletonData")] public string spineSkin;
}
