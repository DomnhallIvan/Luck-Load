using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : ProjectileData
{
    [Header("Referencias")]
    public Rigidbody rb;


    private void Awake()
    {
        //HurtLayer = LayerMask.NameToLayer("enemy");
        //playerLayer = LayerMask.NameToLayer("turret");
        endZoneLayer = LayerMask.NameToLayer("endzone");
        //gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        GameManager.instance.onReset += ReturnToPool;
    }

    private void LateUpdate()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == HurtLayer)
        {
            if (collision.gameObject.TryGetComponent(out I_Damagable damagable))
                damagable.TakeDamage(damage);
            /*
            EnemyController enemyref = collision.gameObject.GetComponent<EnemyController>();
            if (enemyref)
                enemyref.Hit(damage);*/

            ReturnToPool();
        }
        if ( collision.gameObject.layer == endZoneLayer)
        {
            ReturnToPool();
        }
    }

    private void ReturnToPool()
    {
        //Can be reused for other variants of Bullets
        ObjectPool pool = FindObjectOfType<ObjectPool>();
        if (pool != null)
        {
            string tag = gameObject.tag; // Use the tag of this GameObject
            pool.ReturnToPool(tag, gameObject);
        }
    }

    //Setear desde TowerShoot cuanto da�o hara las pelotas que lance
    public int ReturnDamage(int setdamage)
    {
        damage = setdamage;
        return damage;
    }

    public void SetHurtLayer(int layer)
    {
        HurtLayer = layer;
    }
}
