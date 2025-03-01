using UnityEngine;
using Solivagant.Core;

namespace Solivagant.Player
{
    public class PlayerIdleState : PlayerState
    {
        private PlayerStateMachine stateMachine;
        private PlayerAnimationController animController;

        public PlayerIdleState(PlayerStateMachine machine, PlayerAnimationController controller)
        {
            stateMachine = machine;
            animController = controller;
        }

        public override void EnterState()
        {
            animController.PlayAnimation("Idle");
        }

        public override void UpdateState() { }

        public override void ExitState()
        {
            animController.StopAnimation("Idle");
        }
    }
}
