using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour,I_Damagable
{
    private int OriginalMaxHealth;
    private int OriginalMaxShield;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health;
    [SerializeField] private int _maxShieldH = 100;
    [SerializeField] private int _currentShieldH;
    [Space]
    [Header("Shield Regen")]
    [SerializeField] private float _damageRegenCountdown;
    [SerializeField] private float _startRegen=8;
    [SerializeField] private int _regenAmount=15;

    [SerializeField] private UIInterface _uiInterface;

    public int CurrentHealth { get => _health; private set => _health = value; }

    public int Maxhealth { get => _maxHealth; private set => _maxHealth = value; }

    public event I_Damagable.TakeDamageEvent OnTakeDamage;
    public event I_Damagable.DeathEvent OnDeath;

    // Start is called before the first frame update
    void Start()
    {
        OriginalMaxHealth = _maxHealth;
        OriginalMaxShield= _maxShieldH;
        _currentShieldH = _maxShieldH;
        _health = _maxHealth;

        // Initialize the bars on start
        _uiInterface?.SetCurrentHealthAbsolute(_health, _maxHealth);
        _uiInterface?.SetCurrentShieldAbsolute(_currentShieldH, _maxShieldH);
    }

    public void TakeDamage(int Damage)
    {
        Debug.Log("Ouch Player");

        StopAllCoroutines();
        int appliedDamage = Mathf.Clamp(Damage, 0, _maxHealth);

        if (_currentShieldH > 0)
        {
            _currentShieldH -= appliedDamage;
            _currentShieldH = Mathf.Max(0, _currentShieldH);

            _uiInterface?.SetCurrentShieldAbsolute(_currentShieldH, _maxShieldH);
            OnTakeDamage?.Invoke(appliedDamage);

            StartCoroutine(ShieldRegen());
            return;
        }

        // If shield is gone, apply damage to health
        _health -= appliedDamage;
        _health = Mathf.Max(0, _health);

        _uiInterface?.SetCurrentHealthAbsolute(_health, _maxHealth);
        OnTakeDamage?.Invoke(appliedDamage);

        StartCoroutine(ShieldRegen());

        if (_health <= 0)
        {
            OnDeath?.Invoke(transform.position);
        }

    }

    private IEnumerator ShieldRegen()
    {
        yield return new WaitForSeconds(_startRegen);

        while (_currentShieldH < _maxShieldH)
        {
            _currentShieldH += _regenAmount;
            _currentShieldH = Mathf.Min(_currentShieldH, _maxShieldH);

            _uiInterface?.SetCurrentShieldAbsolute(_currentShieldH, _maxShieldH);

            yield return new WaitForSeconds(0.5f);
        }
    }

    //Shopping
    public void RestoreHealth()
    {
        CurrentHealth = _maxHealth;
        _uiInterface?.SetCurrentHealthAbsolute(CurrentHealth, _maxHealth);
    }

    public void MoreShield(int Quantity)
    {
        _maxShieldH += Quantity;
        _currentShieldH += Quantity;
    }

    public void MoreHealth(int Quantity)
    {
        _maxHealth += Quantity;
        CurrentHealth += Quantity;
        Debug.Log(_maxHealth);
    }

    //Reseting UsingGameManager
    public void SetCurrentHealth()
    {
        _maxHealth = OriginalMaxHealth;
        CurrentHealth = _maxHealth;
        _uiInterface?.SetCurrentHealthAbsolute(CurrentHealth, _maxHealth);
        
    }

    public void SetCurrentShiled()
    {
        _maxShieldH = OriginalMaxShield;
        _currentShieldH = _maxShieldH;
        _uiInterface?.SetCurrentHealthAbsolute(_currentShieldH, _maxShieldH);
    }

    public void SetCurrentRegen()
    {
        _startRegen = 8;
    }

    public void LessRegenTime(int Quantity)
    {
        if(_startRegen > 4)
        _startRegen-=Quantity;
    }
}
