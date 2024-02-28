using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class State_Idle : State
{
    private float minTargetDistance = 10f;
    private float playerDistance => VectorUtils.DistanceXZ(stateController.transform.position, player.position);
    public Transform player;

    public override void OnEnter(StateController stateController){
        base.OnEnter(stateController);
        FindPlayer();
    }

    public override void OnUpdate(){
        if(player == null) return;

        if(playerDistance < minTargetDistance){
            stateController.SwitchStage(stateController.stateChase);
            return;
        }
    }

    public override void OnExit(){
        player = null;
    }

    void FindPlayer(){
        var getTarget = GameObject.FindGameObjectWithTag("Player");
        player = getTarget.transform ?? null;
    }

}
