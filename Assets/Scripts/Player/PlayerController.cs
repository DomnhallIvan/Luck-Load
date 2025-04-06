using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputController _inputController;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerInteraction _playerInteraction;
    public bool isDead;
    public int scoreCoins;
    public int scoreEnemy;
    public int waveCount;

    private void OnDestroy() => UnsubscribeEvents();

    private void Start()
    {
        SuscribeEvents();
        //_playerHealth.OnDeath += Die;
    }

    public void ResetStats()
    {
        scoreCoins = 0;
        scoreEnemy = 0;

        waveCount = 0;
    }

    private void Update()
    {
        if (!isDead)
        _playerMovement.MovePlayer(_inputController.MoveInput);
        _playerAttack.AimPlayer();
    }

    private void SuscribeEvents()
    {
        //_inputController.OnInteract+=
        _inputController.OnAttack += HandlePrimaryShoot;
        _inputController.OnSecondaryAttack += HandleSecondaryShoot;
    }

    private void UnsubscribeEvents()
    {
        _inputController.OnAttack -= HandlePrimaryShoot;
        _inputController.OnSecondaryAttack -= HandleSecondaryShoot;
    }

    private void HandlePrimaryShoot()
    {
        if (!isDead)
            _playerAttack.TryShoot();
    }

    private void HandleSecondaryShoot()
    {
        if (!isDead)
            _playerAttack.TrySecondary();
    }
}
