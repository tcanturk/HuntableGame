using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public BaseState currentState;
    public float value;
    public event Action<string> onChangeState;

    virtual public void Init() {
        currentState = GetInitialState();
        if(currentState != null){
            currentState.EnterState();
            if(onChangeState != null) {
                onChangeState(currentState.name);
            }
        }
    }

    virtual public void Update()
    {
        if(currentState != null){
            currentState.UpdateState();
        }
    }

    public void ChangeState(BaseState newState)
    {
        if(currentState != newState) {
            if(currentState != null){
                currentState.ExitState();
            }

            currentState = newState;
            if(currentState != null){
                currentState.EnterState();
                if(onChangeState != null) {
                    onChangeState(currentState.name);
                }
            }
        }
    }


    virtual public BaseState GetInitialState(){
        return null;
    }




    
}
