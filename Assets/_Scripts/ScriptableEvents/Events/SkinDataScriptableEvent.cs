using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "SkinDataScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameCustom + "/Skin Data Scriptable Event",
        order = ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class SkinDataScriptableEvent : BaseScriptableEvent<SkinData>
    {
    }
}
