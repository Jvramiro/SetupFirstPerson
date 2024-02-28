using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class State_Chase : State
{
    private float minTargetDistance = 10f;
    private float targetDistance => VectorUtils.DistanceXZ(stateController.transform.position, target.position);
    private Transform target;

    public override void OnEnter(StateController stateController){
        base.OnEnter(stateController);
        FindTarget();
    }

    public override void OnUpdate(){
        if(target == null) return;

        if(targetDistance > minTargetDistance){
            stateController.SwitchStage(stateController.stateIdle);
            return;
        }

        if(targetDistance < 2f){

        }
        else if(targetDistance < minTargetDistance){
            Vector3 direction = (target.transform.position - stateController.transform.position).normalized;
            stateController.rb.velocity = direction * stateController.velocity * Time.deltaTime * 10;
            if(direction != Vector3.zero){
                Quaternion rotation = Quaternion.LookRotation(direction);
                stateController.transform.rotation = Quaternion.RotateTowards(stateController.transform.rotation, rotation, stateController.rotationVelocity * Time.deltaTime);
            }
        }
    }

    public override void OnExit(){
        target = null;
    }

    void FindTarget(){
        var getTarget = GameObject.FindGameObjectWithTag("Player");
        target = getTarget.transform ?? null;
    }
}
