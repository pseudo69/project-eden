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
    
    public void onMovement(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rigidBody.MovePosition(rigidBody.position + moveDirection * MOVEMENT_SPEED * Time.fixedDeltaTime);
    }
}
