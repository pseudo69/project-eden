using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController
{
    public void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("OnMove");
        Debug.Log(context);

    }
}