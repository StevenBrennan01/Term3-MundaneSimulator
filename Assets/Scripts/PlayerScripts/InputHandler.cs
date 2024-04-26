using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInputActions InputActions; //auto generated script
    private PlayerController ControllerSCR;
    private PlayerInteract InteractSCR;

    private Coroutine MoveCR;

    private bool IsMoving;

    private void Awake()
    {
        InputActions = new PlayerInputActions();
        ControllerSCR = GetComponent<PlayerController>();
        InteractSCR = GetComponent<PlayerInteract>();
    }

    private void OnEnable()
    {
        InputActions.Player.Movement.performed += MovementActionPerformed;
        InputActions.Player.Movement.canceled += MovementActionCanceled;
        InputActions.Player.Movement.Enable();

        InputActions.Player.Interact.performed += InteractButton;
        InputActions.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        InputActions.Player.Movement.performed -= MovementActionPerformed;
        InputActions.Player.Movement.canceled -= MovementActionCanceled;
        InputActions.Player.Movement.Disable();

        InputActions.Player.Interact.performed -= InteractButton;
        InputActions.Player.Interact.Disable();
    }

    private void InteractButton(InputAction.CallbackContext context)
    {
        Debug.Log("Input Detected!");
        InteractSCR.ObjectInteract();
    }

    private void MovementActionPerformed(InputAction.CallbackContext context)
    {
        ControllerSCR.movDir = context.ReadValue<Vector2>();
        IsMoving = true;
        if (MoveCR == null)
        {
            MoveCR = StartCoroutine(CR_MoveUpdate());
        }
    }

    private void MovementActionCanceled(InputAction.CallbackContext context)
    {
        ControllerSCR.movDir = context.ReadValue<Vector2>();
        IsMoving = false;
        if (MoveCR != null)
        {
            StopCoroutine(MoveCR);
            MoveCR = null;
        }
    }

    IEnumerator CR_MoveUpdate()
    {
        while (IsMoving)
        {
            ControllerSCR.Walk();
            yield return null;
        }
    }
}