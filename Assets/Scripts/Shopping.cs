using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopping : MonoBehaviour
{
    [SerializeField] private PlayerController _playerRef;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerHealth _playerHealth;

    public void FullHealth()
    {
        if (_playerRef.scoreCoins >= 5)
        {
            _playerHealth.RestoreHealth();
            _playerRef.scoreCoins -= 5;
            GameManager.instance.ChangeCoinValue();
        }
    }

    public void MoreHealth()
    {
        if (_playerRef.scoreCoins >= 5)
        {
            _playerHealth.MoreHealth(30);
            _playerRef.scoreCoins -= 5;
            GameManager.instance.ChangeCoinValue();
        }
    }

    public void MoreShield()
    {
        if (_playerRef.scoreCoins >= 5)
        {
            _playerHealth.MoreShield(30);
            _playerRef.scoreCoins -= 5;
            GameManager.instance.ChangeCoinValue();
        }
    }

    public void AllMisiles()
    {
        if (_playerRef.scoreCoins >= 5)
        {
            _playerAttack.RechargeMissiles();
            _playerRef.scoreCoins -= 5;
            GameManager.instance.ChangeCoinValue();
        }
    }

    public void MoreMissiles()
    {
        if (_playerRef.scoreCoins >= 5)
        {
            _playerAttack.MoreMissiles(1);
            _playerRef.scoreCoins -= 5;
            GameManager.instance.ChangeCoinValue();
        }
    }

    public void LessShieldRegenTime()
    {
        if (_playerRef.scoreCoins >= 5)
        {
            _playerHealth.LessRegenTime(1);
            _playerRef.scoreCoins -= 5;
            GameManager.instance.ChangeCoinValue();
        }
    }

    public void FullShield()
    {
        if (_playerRef.scoreCoins >= 5)
        {
            _playerHealth.SetCurrentShiled();
            _playerRef.scoreCoins -= 5;
            GameManager.instance.ChangeCoinValue();
        }
    }
}
