using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInputActions _inputActionsSCR;
    private PlayerController _playerControllerSCR;
    private PlayerPickup _playerPickupSCR;

    private Coroutine moveCR;

    private bool isMoving;

    private void Awake()
    {
        _inputActionsSCR = new PlayerInputActions();
        _playerControllerSCR = GetComponent<PlayerController>();
        _playerPickupSCR = GetComponent<PlayerPickup>();
    }

    private void OnEnable()
    {
        _inputActionsSCR.Player.Movement.Enable();
        _inputActionsSCR.Player.Movement.performed += MovementActionPerformed;
        _inputActionsSCR.Player.Movement.canceled += MovementActionCanceled;

        _inputActionsSCR.Player.Interact.Enable();
        _inputActionsSCR.Player.Interact.performed += InteractButton;

        _inputActionsSCR.Player.ThrowObject.Enable();
        _inputActionsSCR.Player.ThrowObject.performed += ThrowObjectButton;
    }

    private void OnDisable()
    {
        _inputActionsSCR.Player.Movement.Disable();
        _inputActionsSCR.Player.Movement.performed -= MovementActionPerformed;
        _inputActionsSCR.Player.Movement.canceled -= MovementActionCanceled;

        _inputActionsSCR.Player.Interact.Disable();
        _inputActionsSCR.Player.Interact.performed -= InteractButton;

        _inputActionsSCR.Player.ThrowObject.Disable();
        _inputActionsSCR.Player.ThrowObject.performed -= ThrowObjectButton;
    }

    private void MovementActionPerformed(InputAction.CallbackContext value)
    {
        _playerControllerSCR.movDir = value.ReadValue<Vector2>();
        isMoving = true;
        if (moveCR == null)
        {
            moveCR = StartCoroutine(CR_MoveUpdate());
        }
    }

    private void MovementActionCanceled(InputAction.CallbackContext value)
    {
        _playerControllerSCR.movDir = value.ReadValue<Vector2>();
        isMoving = false;
        if (moveCR != null)
        {
            StopCoroutine(moveCR);
            moveCR = null;
        }
    }

    IEnumerator CR_MoveUpdate()
    {
        while (isMoving)
        {
            _playerControllerSCR.Walk();
            yield return null;
        }
    }

    private void InteractButton(InputAction.CallbackContext button)
    {
        _playerPickupSCR.ObjectInteract();
    }

    private void ThrowObjectButton(InputAction.CallbackContext button)
    {
        _playerPickupSCR.ObjectThrow();
    }
}