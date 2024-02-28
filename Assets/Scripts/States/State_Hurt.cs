using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Hurt : State
{
    public override void OnEnter(StateController stateController){
        base.OnEnter(stateController);
        stateController.Invoke(nameof(stateController.StateIdle),3f);
    }

}
