using _Scripts.Spine;
using ScriptableEvents;
using UnityEngine;

namespace _Scripts.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameCustom + "/Skin Data Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderCustom + 0
    )]
    public class SkinDataScriptableEventListener : BaseScriptableEventListener<SkinData>
    {
    }
}