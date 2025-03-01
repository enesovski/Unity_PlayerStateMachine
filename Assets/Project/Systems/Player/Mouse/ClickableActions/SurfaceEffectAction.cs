using UnityEngine;
using Solivagant.Player;

public class SurfaceEffectAction : ClickableAction
{
    public SurfaceEffectAction(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Execute(RaycastHit hit)
    {
        Debug.Log("SurfaceEffectAction invoked.");

        playerStateMachine.NotifyActionCompleted(hit);
    }
}
