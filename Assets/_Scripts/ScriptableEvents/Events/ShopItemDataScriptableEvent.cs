using ScriptableEvents;
using UnityEngine;
using Utility;

namespace _Scripts.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ShopItemDataScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameCustom + "/Shop Item Data Scriptable Event",
        order = ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class ShopItemDataScriptableEvent : BaseScriptableEvent<ShopItemData>
    {
    }
}