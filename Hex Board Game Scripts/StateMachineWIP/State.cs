using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    private StateMachine _stateMachine;

    public State(StateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public virtual void StateStart()
    {
        Debug.Log($"State: {this.GetType().Name} is ON!");
    }

    protected virtual void StateTick()
    {
        Debug.Log($"State: {this.GetType().Name} is TICKING!");
    }

    protected virtual void StateEnd()
    {
        Debug.Log($"State: {this.GetType().Name} is OFF!");
    }
}
