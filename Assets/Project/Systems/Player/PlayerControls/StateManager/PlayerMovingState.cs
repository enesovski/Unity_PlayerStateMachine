using UnityEngine;
using UnityEngine.AI;
using Solivagant.Core;

namespace Solivagant.Player
{
    public class PlayerMovingState : PlayerState
    {
        private PlayerStateMachine stateMachine;
        private PlayerAnimationController animController;
        private NavMeshAgent agent;
        public RaycastHit target;

        public PlayerMovingState(PlayerStateMachine machine, PlayerAnimationController controller)
        {
            stateMachine = machine;
            animController = controller;
            agent = machine.GetComponent<NavMeshAgent>();
        }

        public override void EnterState()
        {
            if (agent != null)
            {
                agent.SetDestination(target.point);
                animController.PlayAnimation("Run");
            }
        }

        public void SetTarget(RaycastHit newTarget)
        {
            target = newTarget;
        }

        public override void UpdateState()
        {
            if (agent != null && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                CompleteState(target);
                stateMachine.SetState(stateMachine.IdleState);
                stateMachine.NotifyActionCompleted(target);
                stateMachine.actionQueue.NotifyActionCompleted(target);
            }
        }

        public override void ExitState()
        {
            animController.StopAnimation("Run");
        }
    }
}
