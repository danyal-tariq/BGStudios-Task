using _Scripts.Spine;
using ScriptableEvents;
using UnityEngine;

namespace _Scripts.ScriptableEvents.Events
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