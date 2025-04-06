using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Shoot_Data,I_Shoot
{   
    private List<GameObject> _enemiesInRange = new List<GameObject>();
    private GameObject currentTarget;
    private ObjectPool bulletPool;
    private float lastFireTime = 0f;

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemiesInRange.Add(other.gameObject);
            UpdateTarget();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemiesInRange.Remove(other.gameObject);
            currentTarget = null;
            UpdateTarget();
        }
    }

    private void UpdateTarget()
    {
        //Filters out null enemies
        _enemiesInRange.RemoveAll(enemy => enemy == null); // Remove destroyed enemies

        //Checks if the current target is null or no longer valid
        if (currentTarget != null && _enemiesInRange.Contains(currentTarget))
        {
            return;
        }

        GameObject closestEnemy = null;
        float closestDistance = float.MaxValue;

        foreach (GameObject enemy in _enemiesInRange)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        currentTarget = closestEnemy;

    }

    private void LateUpdate()
    {
        if (currentTarget != null)
        {
            //AimAtTarget();
            TryShoot();
        }
    }

   

    private void AimAtTarget()
    {

        Vector3 aimAt = new Vector3(currentTarget.transform.position.x, _core.transform.position.y, currentTarget.transform.position.z);
        float distToTarget = Vector3.Distance(aimAt, _gun.transform.position);

        Vector3 relativeTargetPosition = _gun.transform.position + (_gun.transform.forward * distToTarget);

        relativeTargetPosition = new Vector3(relativeTargetPosition.x, currentTarget.transform.position.y, relativeTargetPosition.z);

        _gun.transform.rotation = Quaternion.Slerp(_gun.transform.rotation, Quaternion.LookRotation(relativeTargetPosition - _gun.transform.position), Time.deltaTime * _turningSpeed);
        _core.transform.rotation = Quaternion.Slerp(_core.transform.rotation, Quaternion.LookRotation(aimAt - _core.transform.position), Time.deltaTime * _turningSpeed);
    }

    public void TryShoot()
    {
        if (Time.time - lastFireTime >= _fireRate)
        {
           
                NormalShoot(_firePoint.position, _firePoint.forward);
                lastFireTime = Time.time;
            
        }
    }

    public void TrySecondary()
    {
        if (Time.time - lastFireTime >= _fireRate)
        {
           
               SecondaryShoot(_firePoint.position, _firePoint.forward);
                lastFireTime = Time.time;
            
        }
    }

    public void NormalShoot(Vector3 firePointPosition, Vector3 fireDirection)
    {
        GameObject fireObject = bulletPool.GetFromPool("Bullet");
        if( fireObject != null )
        FireBullet(firePointPosition, fireDirection, fireObject);
    }

    public void SecondaryShoot(Vector3 firePointPosition, Vector3 fireDirection)
    {
        //Instead of Using prefabBullet it would use PrefabMisile
        GameObject fireObject = bulletPool.GetFromPool("Missile");
        if (fireObject != null)
        FireBullet(firePointPosition, fireDirection,fireObject);   

    }    

    private void FireBullet(Vector3 firePointPosition, Vector3 fireDirection, GameObject fireObject)
    {

        fireObject.transform.position = firePointPosition;
        fireObject.transform.rotation = Quaternion.identity;

        Rigidbody bulletRB = fireObject.GetComponent<Rigidbody>();
        if (bulletRB != null)
        {
            bulletRB.velocity = Vector3.zero;
            bulletRB.angularVelocity = Vector3.zero;
            bulletRB.AddForce(fireDirection * _bulletForce, ForceMode.Impulse);

            Projectile projectile = fireObject.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.ReturnDamage(_damage);
                projectile.SetHurtLayer(LayerMask.NameToLayer("Player")); // or "enemy", "turret" etc.
            }
        }
    }

}
