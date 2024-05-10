using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    private TrashPiece _trashPieceSCR;

    [SerializeField]
    private LayerMask pickupLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private Transform cameraHoldPointTransform;

    private float rayRange = 2.55f;

    private RaycastHit rayCastHit;
    
    public void ObjectInteract()
    {
        if (_trashPieceSCR == null) //player is not currently holding an object
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out rayCastHit, rayRange, pickupLayerMask))
            {
                if (rayCastHit.transform.TryGetComponent(out _trashPieceSCR))
                {
                    _trashPieceSCR.GrabObject(cameraHoldPointTransform);
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