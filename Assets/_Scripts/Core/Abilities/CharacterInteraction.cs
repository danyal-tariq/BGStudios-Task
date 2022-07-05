using ScriptableEvents.Events;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    [SerializeField] private BoolScriptableEvent interactionAvailableEvent;
     private IInteractable interactableNpc;


    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            if(interactableNpc != null )
            {
                interactableNpc.Interact(); 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        interactableNpc = col.collider.GetComponentInChildren<IInteractable>();
        if (interactableNpc != null)
        {
            interactionAvailableEvent.Raise(true);
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(interactableNpc.Equals(other.collider.GetComponentInChildren<IInteractable>()))
        {
            interactableNpc = null;
            interactionAvailableEvent.Raise(false);

        }
    }


    
    
}
