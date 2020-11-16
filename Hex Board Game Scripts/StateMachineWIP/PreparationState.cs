using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreparationState : State
{
    private StateMachine stateMachine;

    public PreparationState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void StateStart()
    {
        base.StateStart();

        //Przygotuj planszę - 

        //Przygotuj talie

        //Przygotuj graczy
    }

    protected override void StateTick()
    {
        base.StateTick(); 
    }

    protected override void StateEnd()
    {
        base.StateEnd();
    }
}
