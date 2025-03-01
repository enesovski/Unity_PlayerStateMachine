using UnityEngine;

namespace Solivagant.Interaction
{
    public interface IInteractable
    {

        Sprite GetInteractionIcon();
        void Interact();

    }

}
