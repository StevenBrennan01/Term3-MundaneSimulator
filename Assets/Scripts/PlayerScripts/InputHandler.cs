using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class InputHandler : MonoBehaviour
{
    private PlayerInputActions InputActions; //auto generated script
    private PlayerController ControllerSCR;
    private PlayerPickup InteractSCR;

    private Coroutine MoveCR;

    private bool IsMoving;

    private void Awake()
    {
        InputActions = new PlayerInputActions();
        ControllerSCR = GetComponent<PlayerController>();
        InteractSCR = GetComponent<PlayerPickup>();
    }

    private void OnEnable()
    {
        InputActions.Player.Movement.Enable();
        InputActions.Player.Movement.performed += MovementActionPerformed;
        InputActions.Player.Movement.canceled += MovementActionCanceled;

        InputActions.Player.Interact.Enable();
        InputActions.Player.Interact.performed += InteractButton;
    }

    private void OnDisable()
    {
        InputActions.Player.Movement.Disable();
        InputActions.Player.Movement.performed -= MovementActionPerformed;
        InputActions.Player.Movement.canceled -= MovementActionCanceled;

        InputActions.Player.Interact.Disable();
        InputActions.Player.Interact.performed -= InteractButton;
    }

    #region Movement Method , Performed & Canceled
    private void MovementActionPerformed(InputAction.CallbackContext value)
    {
        ControllerSCR.movDir = value.ReadValue<Vector2>();
        IsMoving = true;
        if (MoveCR == null)
        {
            MoveCR = StartCoroutine(CR_MoveUpdate());
        }
    }

    private void MovementActionCanceled(InputAction.CallbackContext value)
    {
        ControllerSCR.movDir = value.ReadValue<Vector2>();
        IsMoving = false;
        if (MoveCR != null)
        {
            StopCoroutine(MoveCR);
            MoveCR = null;
        }
    }
    #endregion

    #region Interact Method
    private void InteractButton(InputAction.CallbackContext button)
    {
        InteractSCR.ObjectInteract();
    }
    #endregion

    IEnumerator CR_MoveUpdate()
    {
        while (IsMoving)
        {
            ControllerSCR.Walk();
            yield return null; //make sure to return null, this is what was missing
        }
    }
}