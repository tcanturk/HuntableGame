using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{

    public IdleState(string argName, StateMachine argSM) : base (argName, argSM) {

    }

    override public void EnterState(){
        sm.value = 0f;
    }
    
}
