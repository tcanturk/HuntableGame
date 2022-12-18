using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntableSM : StateMachine
{
    public BaseState passiveState;
    public BaseState idleState;
    public BaseState focusState;
    public BaseState huntState;

    override public void Init() {

        passiveState = new IdleState("passive", this);
        idleState = new IdleState("idle", this);
        focusState = new FocusState("focus", this);
        huntState = new HuntState("hunt", this);

        base.Init();
    }

    public void SetFillSpeed(float fillSpeed){
        (focusState as FocusState).FillSpeed = fillSpeed;
    }

    virtual public void Update() {
        base.Update();
        if(value >= 1.0f) {
            ChangeState(huntState);
        }
    }

    override public BaseState GetInitialState(){
        return passiveState;
    }

    public void Reset(){
        ChangeState(idleState);
    }

    public void Focus() {
        if(currentState.name == "idle") {
            ChangeState(focusState);
        }
    }

    public void Active() {
        if(currentState.name == "passive") {
            ChangeState(idleState);
        }
    }

    public void Passive() {
        if(currentState.name != "passive") {
            ChangeState(passiveState);
        }
    }

}
