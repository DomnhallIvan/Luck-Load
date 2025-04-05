using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;

public class SpawnOnDeath : MonoBehaviour
{
    //[SerializeField] private ParticleSystem _deathSystem;
    //[SerializeField] private GameObject _deathObject;
    private ObjectPool coinPool;
    public I_Damagable Damagable;

    private void Awake()
    {
        Damagable=GetComponent<I_Damagable>();
    }

    private void OnEnable()
    {
        Damagable.OnDeath += Damageable_OnDeath;
    }

    private void Damageable_OnDeath(Vector3 Position)
    {
        int chance = Random.Range(0, 4);
        if (chance == 0)
        {
            GameObject coinObject = coinPool.GetFromPool("Coin");
            //Instantiate in 1/10 chance
            Instantiate(coinObject, Position, Quaternion.identity);
        }
        
    }
}

