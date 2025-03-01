using UnityEngine;

namespace Solivagant.Interaction
{
    public abstract class Interactable : MonoBehaviour, IInteractable
    {
        [SerializeField] Sprite interactionIcon;
        public Sprite GetInteractionIcon() => interactionIcon;
        public abstract void Interact();
    }

}
