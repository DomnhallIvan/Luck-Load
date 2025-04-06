using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerAttack : Shoot_Data,I_Shoot
{
    [SerializeField] private LayerMask groundMask;
    private Camera mainCamera;
    [SerializeField] private PlayerController controller;
    private ObjectPool bulletPool;
    private float lastFireTime = 0f;
    [SerializeField] private float _fireRate2=1.5f;
    public int originalMaxMissiles;
    public int maxMissiles = 2;
    public int ammoMisiles;

    private void Start()
    {
        mainCamera = Camera.main;
        originalMaxMissiles=maxMissiles ;
        ammoMisiles = maxMissiles;
    }

    private void Awake()
    {
        bulletPool = FindObjectOfType<ObjectPool>();
    }

    private void Update()
    {
       // AimPlayer();
    }

    public void AimPlayer()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
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
        if (Time.time - lastFireTime >= _fireRate2)
        {
            ammoMisiles--;
            if (ammoMisiles > 0)
            SecondaryShoot(_firePoint.position, _firePoint.forward);
            lastFireTime = Time.time;

        }
    }

    public void NormalShoot(Vector3 firePointPosition, Vector3 fireDirection)
    {
        GameObject fireObject = bulletPool.GetFromPool("Bullet");
        if (fireObject != null)
            FireBullet(firePointPosition, fireDirection, fireObject);
    }

    public void SecondaryShoot(Vector3 firePointPosition, Vector3 fireDirection)
    {
        //Instead of Using prefabBullet it would use PrefabMisile
        GameObject fireObject = bulletPool.GetFromPool("Missile");
        if (fireObject != null)
            FireBullet(firePointPosition, fireDirection, fireObject);

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
                projectile.SetHurtLayer(LayerMask.NameToLayer("enemy")); // or "enemy", "turret" etc.
            }
        }
    }

    public void RechargeMissiles()
    {
        ammoMisiles = maxMissiles;
    }

    public void MoreMissiles(int Quantity)
    {
        maxMissiles += Quantity;
        ammoMisiles += Quantity;
    }
}
