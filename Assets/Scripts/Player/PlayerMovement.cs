using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //public S_Stats playerStats;
    public float speed=5f;
    private Vector2 move;

    private void Start()
    {
        //playerStats = new S_Stats(100, 100, 12, 3, 1.2f, 5, 20);
    }

    public void MovePlayer(Vector2 moveInput)
    {
         Vector3 movement = new Vector3(moveInput.x, 0f, moveInput.y);

        if (movement != Vector3.zero)
            //transform.rotation=Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(movement),0.15f);

            transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
