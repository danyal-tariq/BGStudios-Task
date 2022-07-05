using Spine.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ShopInventorySO",menuName ="ScriptableObjects/ShopInventory")]
public class ShopInventory : ScriptableObject
{
    public List<ShopItem> torsoItems;
    public List<ShopItem> legItems;
    public List<ShopItem> accessoryItems;
    public SkeletonDataAsset skeletonData;

    [Header("Json Fields")]
    private InventoryData inventoryData;

    public string fileName;
    private string path;
    public void LoadData()
    {
        path = Path.Combine(Application.persistentDataPath, fileName);
        if (File.Exists(path))
        {
            var json = File.ReadAllText(path);
            inventoryData = JsonUtility.FromJson<InventoryData>(json);
            
            for (var index = 0; index < torsoItems.Count; index++)
            {
                var bought = inventoryData.torsoStatus[index];
                torsoItems[index].isBought = bought;
            }
            for (var index = 0; index < legItems.Count; index++)
            {
                var bought = inventoryData.legStatus[index];
                legItems[index].isBought = bought;
            }
            for (var index = 0; index < accessoryItems.Count; index++)
            {
                var bought = inventoryData.accessoryStatus[index];
                accessoryItems[index].isBought = bought;
            }
        }
        else
        {
            inventoryData = new InventoryData()
            {
                torsoStatus = new bool[torsoItems.Count],
                legStatus = new bool[legItems.Count],
                accessoryStatus = new bool[accessoryItems.Count]
            };
            SaveData();
        }

    }

    public void SaveData()
    {
        for (var index = 0; index < torsoItems.Count; index++)
        {
            var item = torsoItems[index];
            inventoryData.torsoStatus[index] = item.isBought;
        }
        for (var index = 0; index < legItems.Count; index++)
        {
            var item = legItems[index];
            inventoryData.legStatus[index] = item.isBought;
        }
        for (var index = 0; index < accessoryItems.Count; index++)
        {
            var item = accessoryItems[index];
            inventoryData.accessoryStatus[index] = item.isBought;
        }

        var json = JsonUtility.ToJson(inventoryData);
        File.WriteAllText(path,json);
    }
    [ContextMenu("Delete File")]
    public void DeleteData()
    {
        path = Path.Combine(Application.persistentDataPath, fileName);
        File.Delete(path);
        RefreshEditorProjectWindow();
    }

    private void RefreshEditorProjectWindow() 
    {
    #if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
    #endif
    }
}
[Serializable]
public class ShopItem
{
    public int id;
    public string name;
    public ItemType type;
    public int price;
    public bool isBought;
    [SpineSkin(dataField ="skeletonData")] public string spineSkin;
}

public enum ItemType
{
    Torso,
    Legs,
    Accessory,
    Head
}

public struct InventoryData
{
    public bool[] torsoStatus;
    public bool[] legStatus;
    public bool[] accessoryStatus;
}
