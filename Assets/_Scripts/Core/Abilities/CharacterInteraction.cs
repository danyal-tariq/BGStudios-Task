using _Scripts.Interfaces;
using ScriptableEvents.Events;
using UnityEngine;

namespace _Scripts.Core.Abilities
{
    public class CharacterInteraction : MonoBehaviour
    {
        [SerializeField] private BoolScriptableEvent interactionAvailableEvent;
        private IInteractable interactable;


        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (interactable != null)
                {
                    interactable.Interact();
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            interactable = col.collider.GetComponentInChildren<IInteractable>();
            if (interactable != null)
            {
                interactionAvailableEvent.Raise(true);
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (interactable == null) return;
            if (interactable.Equals(other.collider.GetComponentInChildren<IInteractable>()))
            {
                interactable = null;
                interactionAvailableEvent.Raise(false);
            }
        }
    }
}