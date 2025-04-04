using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public S_Stats playerStats;
    //public float speed=5f;
    private Vector2 move;

    private void Start()
    {
        playerStats = new S_Stats(100, 100, 12, 3, 1.2f, 5, 20);
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        move = callbackContext.ReadValue<Vector2>();
    }

    private void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        Vector3 movement = new Vector3(move.x, 0f, move.y);

        if(movement != Vector3.zero)
        //transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),0.15f);
       
        transform.Translate(movement * playerStats.speed * Time.deltaTime, Space.World);
    }
}
