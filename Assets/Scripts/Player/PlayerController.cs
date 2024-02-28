using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float velocity = 5, force;
    private Vector2 inputMovement;
    public Vector2 InputMovement { get{return inputMovement;} set{inputMovement = value;}}
    Vector3 movementDirection;

    [Header("Ground Verification")]
    [SerializeField] private float groundOffset = -1, groundRadius = 0.2f;
    [SerializeField] private Collider playerCollider;

    private bool isCrouching;
    private float crouchingMultiplier => isCrouching ? 0.5f : 1f;

    public event Action onJump;

    void Start(){
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void FixedUpdate(){
        Move();
    }

    void Move(){
        movementDirection = Camera.main.transform.forward * InputMovement.y + Camera.main.transform.right * inputMovement.x;
        movementDirection.Normalize();
        Vector3 movement = movementDirection * velocity * crouchingMultiplier;
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    public void Jump(){
        if(!CanJump()) return;
        rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        rb.AddForce(Vector3.up * force * 10);
        onJump?.Invoke();
    }
    private bool CanJump(){
        Collider[] colliders = Physics.OverlapSphere(groundCheck, groundRadius);
        return colliders.Count(c => !c.isTrigger && c != playerCollider) > 0 && !isCrouching;
    }
    public void Crouch(bool value) => isCrouching = value;

    private Vector3 groundCheck => transform.position + new Vector3(0,groundOffset,0);
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundCheck, groundRadius);
    }
}
