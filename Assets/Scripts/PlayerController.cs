using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    private const float MOVEMENT_SPEED = 5f;
    private Vector2 moveDirection;
    public Animator animator;
    
    public void onMovement(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();

    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * MOVEMENT_SPEED * Time.fixedDeltaTime);

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            animator.SetFloat("lastX", moveDirection.x);
            animator.SetFloat("lastY", moveDirection.y);
        }
       
    }
}
