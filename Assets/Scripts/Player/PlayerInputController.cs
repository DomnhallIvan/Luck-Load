using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public Action OnInteract;
    public Action OnAttack;
    public Action OnSecondaryAttack;
    public Action OnMovement;

    public void OnMove(InputAction.CallbackContext context)
    {
       MoveInput=context.ReadValue<Vector2>();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnInteract?.Invoke();

        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnAttack?.Invoke();
        }
    }

    public void OnSecondaryttackInput(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            OnSecondaryAttack?.Invoke();
        }
    }
}
