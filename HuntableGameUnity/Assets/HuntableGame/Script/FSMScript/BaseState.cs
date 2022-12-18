using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState
{

    public string name;
    protected StateMachine sm;

    public BaseState(string argName, StateMachine argSM) {
        name = argName;
        sm = argSM;
    }

    virtual public void EnterState(){

    }

    virtual public void UpdateState(){
        
    }

    virtual public void ExitState(){
        
    }

}
