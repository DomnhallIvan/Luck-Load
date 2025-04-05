using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,I_Damagable
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health;
    [SerializeField] private int _maxShieldH = 100;
    [SerializeField] private int _currentShieldH;


    public int CurrentHealth { get => _health; private set => _health = value; }

    public int Maxhealth { get => _maxHealth; private set => _maxHealth = value; }

    public event I_Damagable.TakeDamageEvent OnTakeDamage;
    public event I_Damagable.DeathEvent OnDeath;

    public void TakeDamage(int Damage)
    {
        Debug.Log("Ouch");
        int damageTaken = Mathf.Clamp(Damage, 0, CurrentHealth);

        CurrentHealth -= damageTaken;

        if (damageTaken != 0)
        {
            OnTakeDamage?.Invoke(damageTaken);
        }

        if (CurrentHealth <= 0 && damageTaken != 0)
        {
            OnDeath?.Invoke(transform.position);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentShieldH = _maxShieldH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
