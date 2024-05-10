using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    private TrashPiece _trashPieceSCR;

    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectHoldPointTransform;

    private float rayRange = 2.55f;

    private RaycastHit rayCastHit;

    [HideInInspector] public bool isHolding = false;
    
    public void ObjectInteract()
    {
        if (_trashPieceSCR == null) //player is not currently holding an object
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out rayCastHit, rayRange, pickupLayerMask)) //detecting for layermask
            {
                if (rayCastHit.transform.TryGetComponent(out _trashPieceSCR)) //checking if layer has script
                {
                    _trashPieceSCR.GrabObject(objectHoldPointTransform);
                }
            }
            isHolding = true;

            //try and put throw code here then into input handler
            //rb.AddForce(transform forward * throwForce, ForceMode2D.Impulse) * time.deltatime?;

        }
        else //player is holding an object
        {
            _trashPieceSCR.DropObject();
            _trashPieceSCR = null;
            isHolding = false;
        }
    }
}