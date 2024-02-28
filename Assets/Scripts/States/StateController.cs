using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    public Rigidbody rb;
    public float velocity = 10f, rotationVelocity = 10f;
    private State currentState;

    public State stateIdle = new State_Idle();
    public State stateChase = new State_Chase();
    public State stateHurt = new State_Hurt();

    [SerializeField] private string stateIndicator;

    void Start(){
        SwitchStage(stateIdle);
    }
    void Update(){
        currentState?.OnUpdate();
    }

    public void SwitchStage(State state){
        if(currentState == state) return;
        //Debug.Log($"Mudando de {currentState} para {state}");
        currentState?.OnExit();
        currentState = state;
        currentState.OnEnter(this);
        stateIndicator = $"{state}";
    }

    public void StateIdle() => SwitchStage(stateIdle);
    public void StateHurt() => SwitchStage(stateHurt);
}
