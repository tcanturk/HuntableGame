using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusState : BaseState
{

    float fillSpeed;

    public FocusState(string argName, StateMachine argSM) : base (argName, argSM) {

    }

    public float FillSpeed {
        set {fillSpeed = value;}
    }

    override public void UpdateState(){
        sm.value += fillSpeed;
    }
    
}
