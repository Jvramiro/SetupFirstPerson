using UnityEngine;

public abstract class State{
    public StateController stateController;
    public virtual void OnEnter(StateController stateController){
        this.stateController = stateController;
    }
    public virtual void OnUpdate(){
    }
    public virtual void OnExit(){
    }
}