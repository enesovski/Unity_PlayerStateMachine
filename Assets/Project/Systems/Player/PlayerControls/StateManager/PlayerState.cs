using Solivagant.Core;
using Solivagant.Player;
using System;
using UnityEngine;

public abstract class PlayerState : IState<PlayerStateMachine>
{
    public event Action<RaycastHit> OnComplete;

    protected void CompleteState(RaycastHit hit)
    {
        OnComplete?.Invoke(hit); 
    }

    public abstract void EnterState();

    public abstract void ExitState();

    public abstract void UpdateState();

}
