using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombatScript : MonoBehaviour
{
    private PlayerInputs _inputs;
    private InputAction _playerEquip;
    private InputAction _playerAim;
    private InputAction _playerThrow;
    private InputAction _playerRecal;

    private void OnEnable()
    {
        _playerEquip = _inputs.Combat.Equipe;
        _playerEquip.Enable();
        _playerEquip.performed += _playerEquip_performed;

        _playerAim = _inputs.Combat.Aim;
        _playerAim.Enable();
        _playerAim.performed += _playerAim_performed;
        _playerAim.canceled += _playerAim_canceled;

        _playerThrow = _inputs.Combat.Throw;
        _playerThrow.Enable();

        _playerRecal = _inputs.Combat.Recal;
        _playerRecal.Enable();
    }

    private void _playerEquip_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("axe equiped");
    }

    private void _playerAim_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("aiming");
    }

    private void _playerAim_canceled(InputAction.CallbackContext obj)
    {
        Debug.Log("stop aiming");
    }


    private void Awake()
    {
        _inputs = new PlayerInputs();
    }


    private void OnDisable()
    {
        _playerEquip.Disable();
        _playerAim.Disable();
        _playerThrow.Disable();
        _playerRecal.Disable();
    }
}
