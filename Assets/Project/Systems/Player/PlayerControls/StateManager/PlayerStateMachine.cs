using UnityEngine;
using Solivagant.Core;
using Solivagant.Actions;
using System;

namespace Solivagant.Player
{
    public class PlayerStateMachine : StateMachine<PlayerStateMachine>
    {
        private PlayerAnimationController animController;
        public PlayerActionQueue actionQueue;

        public event Action<RaycastHit> OnActionCompleted;

        public PlayerIdleState IdleState { get; private set; }
        public PlayerMovingState MovingState { get; private set; }

        private void Awake()
        {
            animController = GetComponent<PlayerAnimationController>();
            actionQueue = new PlayerActionQueue(this);

            IdleState = new PlayerIdleState(this, animController);
            MovingState = new PlayerMovingState(this, animController);

            SetState(IdleState);
        }

        public void EnqueueAction(ClickableAction action, RaycastHit hit)
        {
            actionQueue.EnqueueAction(action, hit);
        }

        public void NotifyActionCompleted(RaycastHit hit)
        {
            OnActionCompleted?.Invoke(hit);
            actionQueue.NotifyActionCompleted(hit);
        }
    }
}
