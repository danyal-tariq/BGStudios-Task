using _Scripts.Interfaces;
using ScriptableEvents.Events;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private SimpleScriptableEvent interactionEvent;

    public void Interact()
    {
        interactionEvent.Raise();
    }
}