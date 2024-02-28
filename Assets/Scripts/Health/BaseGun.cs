using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BaseGun : MonoBehaviour
{
    [SerializeField] private float distance, recharge;
    [SerializeField] private int damage;
    public bool isRecharging;
    public void Shoot(){
        if(isRecharging) return;
        OnShoot();

        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distance);
        if(hit.collider != null){
            if(hit.collider.TryGetComponent(out IDamageListener damageListener)){
                damageListener.Damage();
            }
        }
    }

    void OnShoot(){
        isRecharging = true;
        Invoke(nameof(Recharge), recharge);
    }
    void Recharge() => isRecharging = false;


    [SerializeField] private bool drawGizmos;
    void OnDrawGizmosSelected(){
        if(drawGizmos){
            Gizmos.color = Color.red;
            Gizmos.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distance);
        }
    }

    #region input
    private MainInputActions inputActions;
    private InputAction action;
    void OnEnable(){
        inputActions = new MainInputActions();
        action = inputActions.Player.Interact;
        action.Enable();
        action.performed += OnActionPerfomed;
    }
    void OnDisable(){
        action.performed -= OnActionPerfomed;
        action.Disable();
    }
    void OnActionPerfomed(InputAction.CallbackContext context) => Shoot();
    #endregion

}
