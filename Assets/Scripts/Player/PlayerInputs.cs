using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerInteraction playerInteraction;
    private MainInputActions inputActions;
    private InputAction movement, jump, interact, crouch;
    private List<InputAction> actions = new List<InputAction>();
    void OnEnable(){
        inputActions = new MainInputActions();

        movement = inputActions.Player.Movement;
        jump = inputActions.Player.Jump;
        interact = inputActions.Player.Interact;
        crouch = inputActions.Player.Crouch;

        actions = new List<InputAction>(){movement, jump, interact, crouch};
        actions.ForEach(a => a.Enable());

        jump.performed += OnJumpPerfomed;
        interact.performed += OnInteractPerfomed;
        crouch.performed += OnCrouchPerfomed;
        crouch.canceled += OnCrouchCanceled;
    }

    void OnDisable(){
        actions.ForEach(a => a.Disable());

        jump.performed -= OnJumpPerfomed;
        interact.performed -= OnInteractPerfomed;
        crouch.performed -= OnCrouchPerfomed;
        crouch.canceled -= OnCrouchCanceled;
    }

    void Update(){
        if(playerController) playerController.InputMovement = movement.ReadValue<Vector2>();
    }

    void OnJumpPerfomed(InputAction.CallbackContext context) => playerController.Jump();
    void OnInteractPerfomed(InputAction.CallbackContext context) => playerInteraction.Interact();
    void OnCrouchPerfomed(InputAction.CallbackContext context) => playerController.Crouch(true);
    void OnCrouchCanceled(InputAction.CallbackContext context) => playerController.Crouch(false);


}
