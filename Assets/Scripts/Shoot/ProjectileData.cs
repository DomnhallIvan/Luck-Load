using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileData : MonoBehaviour
{
    [Header("Datos")]
    public int HurtLayer;
    public int playerLayer;
    public int endZoneLayer;
    public Vector3 lastVelocity;
    public int damage = 10;
}
