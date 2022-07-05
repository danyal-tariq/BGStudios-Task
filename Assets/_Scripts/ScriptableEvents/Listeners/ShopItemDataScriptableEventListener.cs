using Utility;
using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/Shop Item Data Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class ShopItemDataScriptableEventListener : BaseScriptableEventListener<ShopItemData>
    {
    }
}
