using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_Damagable 
{
   public int CurrentHealth { get; }

    public int Maxhealth { get; }

    public delegate void TakeDamageEvent(int Damage);
    public event TakeDamageEvent OnTakeDamage;

    public delegate void DeathEvent(Vector3 Position);
    public event DeathEvent OnDeath;

    public void TakeDamage(int Damage);
}
