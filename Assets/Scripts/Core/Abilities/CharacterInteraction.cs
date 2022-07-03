using ScriptableEvents.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private BoolScriptableEvent interactionAvaiableEvent;
    [SerializeField] private IInteractable interactableNPC;


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            if(interactableNPC != null )
            {
                interactableNPC.Interact(); 
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        interactableNPC = collision.GetComponentInChildren<IInteractable>();
        if (interactableNPC != null)
        {
            interactionAvaiableEvent.Raise(true);
            print("Available");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(interactableNPC.Equals(collision.GetComponentInChildren<IInteractable>()))
        {
            interactableNPC = null;
            interactionAvaiableEvent.Raise(false);

        }
    }
    
    
}
