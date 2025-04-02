using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        move = callbackContext.ReadValue<Vector2>();
    }

    private void LateUpdate()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
