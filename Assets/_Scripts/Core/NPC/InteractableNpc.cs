using _Scripts.Interfaces;
using ScriptableEvents.Events;
using UnityEngine;

namespace _Scripts.Core.NPC
{
    public class InteractableNpc : MonoBehaviour, IInteractable
    {
        [SerializeField] private StringScriptableEvent dialogueShowEvent;
        [SerializeField] private SimpleScriptableEvent[] additionalEvents;
        [TextArea(3, 5)] [SerializeField] private string dialogue;


        public void Interact()
        {
            dialogueShowEvent.Raise(dialogue);
            foreach (var e in additionalEvents)
            {
                e.Raise();
            }
        }
    }
}