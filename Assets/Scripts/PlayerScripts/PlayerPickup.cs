using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickupLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private Transform objectGrabPointTransform;

    private float rayRange = 2.55f;

    private TrashPiece _trashPieceSCR;

    private RaycastHit raycastHit;

    private void Update()
    { // ==!!   remove update when game is complete   !!==
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * rayRange, Color.magenta);
    } // ==!!   remove update when game is complete   !!==

    public void ObjectInteract()
    {
        if (_trashPieceSCR == null) //player is not currently holding an object
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out raycastHit, rayRange, pickupLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out _trashPieceSCR))
                {
                    _trashPieceSCR.GrabObject(objectGrabPointTransform);
                }
            } 
        }
        else //player is holding an object
        {
            _trashPieceSCR.DropObject();
            _trashPieceSCR = null;
        }
    }
}