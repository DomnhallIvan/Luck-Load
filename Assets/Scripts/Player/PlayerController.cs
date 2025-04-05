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

    private void OnDestroy() => UnsubscribeEvents();

    private void Start()
    {
        SuscribeEvents();
        //_playerHealth.OnDeath += Die;
    }

    

    private void Update()
    {
        if (!isDead)
        _playerMovement.MovePlayer(_inputController.MoveInput);
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
