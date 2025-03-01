using UnityEngine;

namespace Solivagant.Core
{
    public abstract class StateMachine<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected IState<T> currentState;

        public virtual void SetState(IState<T> newState)
        {
            if (currentState != null)
            {
                currentState.ExitState();
            }

            currentState = newState;
            currentState.EnterState();
        }

        protected virtual void Update()
        {
            currentState?.UpdateState();
        }
    }
}
