using System.Collections.Generic;
using UnityEngine;
using Solivagant.Player;

namespace Solivagant.Actions
{
    public class PlayerActionQueue
    {
        private Queue<(ClickableAction action, RaycastHit hit)> actionQueue = new();
        private bool isExecuting = false;
        private PlayerStateMachine playerStateMachine;

        public PlayerActionQueue(PlayerStateMachine playerStateMachine)
        {
            this.playerStateMachine = playerStateMachine;
            this.playerStateMachine.OnActionCompleted += ExecuteNextAction;
        }

        public void EnqueueAction(ClickableAction action, RaycastHit hit)
        {
            actionQueue.Enqueue((action, hit));

            if (!isExecuting)
            {
                isExecuting = true;
                ExecuteNextAction(hit);
            }
        }

        private void ExecuteNextAction(RaycastHit previousHit)
        {
            if (actionQueue.Count == 0)
            {
                isExecuting = false;
                return;
            }

            var (action, hit) = actionQueue.Dequeue();
            action.Execute(hit);
        }

        public void NotifyActionCompleted(RaycastHit hit)
        {
            ExecuteNextAction(hit);
        }

        private void OnDestroy()
        {
            playerStateMachine.OnActionCompleted -= ExecuteNextAction;
        }
    }
}
