using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidBody;
    [SerializeField]
    private float movementSpeed = 5f;
    private Vector2 moveDirection;
    
    public void onMovement(InputAction.CallbackContext context)
    {
        moveDirection = context.ReadValue<Vector2>();
        //rigidBody.position += moveDirection;
    }

    private void FixedUpdate()
    {

        rigidBody.MovePosition(rigidBody.position + moveDirection * movementSpeed * Time.fixedDeltaTime);
    }
}
