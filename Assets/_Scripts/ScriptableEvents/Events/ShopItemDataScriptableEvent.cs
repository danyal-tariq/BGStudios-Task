using Utility;
using UnityEngine;

namespace ScriptableEvents.Events
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
