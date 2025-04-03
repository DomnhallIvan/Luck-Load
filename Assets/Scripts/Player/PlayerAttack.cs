using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerAttack : Shoot_Data,I_Shoot
{
    [SerializeField] private PlayerController controller;
    private ObjectPool bulletPool;



    public void NormalShoot(Vector3 firePointPosition, Vector3 fireDirection)
    {
        GameObject fire = bulletPool.GetFromPool();
        fire.transform.position = firePointPosition;
        fire.transform.rotation = Quaternion.identity;

        Rigidbody bulletRB = fire.GetComponent<Rigidbody>();
        if (bulletRB != null)
        {
            //Fix to reset angularVelocity and set the ForceMode.Impulse
            bulletRB.velocity = Vector3.zero;
            bulletRB.angularVelocity = Vector3.zero;
            bulletRB.AddForce(fireDirection * _bulletForce, ForceMode.Impulse);
            fire.GetComponent<Projectile>().ReturnDamage(_damage);
        }
    }

    public void SecondaryShoot(Vector3 firePointPosition, Vector3 fireDirection)
    {
        throw new System.NotImplementedException();
    }

    public void StrongShoot(Vector3 firePointPosition, Vector3 fireDirection)
    {
        throw new System.NotImplementedException();
    }
}
