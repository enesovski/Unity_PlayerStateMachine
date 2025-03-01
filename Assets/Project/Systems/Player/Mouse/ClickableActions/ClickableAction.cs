using Solivagant.Actions;
using Solivagant.Player;
using UnityEngine;

public abstract class ClickableAction : IClickableAction
{
    protected PlayerStateMachine playerStateMachine;
    public ClickableAction(PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
    }
    public int Priority { get; private set; }
    public abstract void Execute(RaycastHit hit);
}
