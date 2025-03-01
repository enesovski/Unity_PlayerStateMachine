using UnityEngine;
using Solivagant.Player;
using Solivagant.Interaction;

public class InteractableAction : ClickableAction
{
    Interactable targetInteractable;
    public InteractableAction(PlayerStateMachine playerStateMachine, Interactable interactable) : base(playerStateMachine)
    {
        targetInteractable = interactable;
    }

    public override void Execute(RaycastHit hit)
    {
        Debug.Log("Interacted with:" + targetInteractable.transform.name);

        playerStateMachine.NotifyActionCompleted(hit);
    }
}
