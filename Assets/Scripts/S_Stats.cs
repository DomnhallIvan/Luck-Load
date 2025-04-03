using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Stats 
{
    public int maxHealth;
    public int shieldHealth;
    public int ammo1;
    public int ammo2;
    public float frequency;
    public int speed;
    public int damage;

    public S_Stats(int health, int shieldHealth, int ammo1, int ammo2, float frequency, int speed, int damage)
    {
        this.maxHealth = health;
        this.shieldHealth = shieldHealth;
        this.ammo1 = ammo1;
        this.ammo2=ammo2;
        this.frequency = frequency;
        this.speed = speed;
        this.damage = damage;
    }
}
