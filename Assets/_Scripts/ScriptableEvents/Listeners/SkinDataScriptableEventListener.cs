using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/Skin Data Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class SkinDataScriptableEventListener : BaseScriptableEventListener<SkinData>
    {
    }
}
