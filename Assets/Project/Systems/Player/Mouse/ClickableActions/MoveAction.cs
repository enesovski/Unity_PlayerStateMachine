using Solivagant.Player;
using UnityEngine;

namespace Solivagant.Actions
{
    public class MoveAction : ClickableAction
    {

        public MoveAction(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
        {

        }

        public override void Execute(RaycastHit hit)
        {
            Debug.Log("MoveAction started.");
            playerStateMachine.MovingState.target = hit;
            playerStateMachine.SetState(playerStateMachine.MovingState);
        }

    }
}
