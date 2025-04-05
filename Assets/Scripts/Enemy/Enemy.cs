using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyMovement Movement;
    public Health health;


    private void Start()
    {
        health.OnDeath += Die;
    }

    private void Die(Vector3 Position)
    {

        Debug.Log("Elpepe");
        // Movement.StopMoving();
        GameManager.instance.AddScoreEnemyD(15);
       ReturnToPool();
    }

    public void ReturnToPool()
    {
        //Can be reused for other variants of Bullets
        ObjectPool pool = FindObjectOfType<ObjectPool>();
        if (pool != null)
        {
            string tag = gameObject.tag; // Use the tag of this GameObject
            pool.ReturnToPool(tag, gameObject);
        }
    }
    //Atacar y moverse
}
