using ScriptableEvents;
using UnityEngine;
using Utility;

namespace _Scripts.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/Shop Item Data Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class ShopItemDataScriptableEventListener : BaseScriptableEventListener<ShopItemData>
    {
    }
}