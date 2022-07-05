using ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNpc : MonoBehaviour, IInteractable
{
    [SerializeField] private StringScriptableEvent dialogueShowEvent;
    [SerializeField] private SimpleScriptableEvent[] additionalEvents;
    [TextArea(3,5)][SerializeField] private string dialogue;
    
   
    public void Interact()
    {
        dialogueShowEvent.Raise(dialogue);
        foreach(var e in additionalEvents)
        {
            e.Raise();
        }
    }
}
