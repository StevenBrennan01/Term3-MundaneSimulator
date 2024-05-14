using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private TrashPiece _trashPieceSCR;

    [SerializeField] private LayerMask pickupLayerMask;
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectHoldPointTransform;

    [HideInInspector] public bool isHolding = false;
    [SerializeField] private float throwForce = 10f;

    private float rayRange = 2.55f;
    private RaycastHit rayCastHit;

    public void ObjectInteract()
    {
        if (_trashPieceSCR == null) //player is NOT currently holding an object
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out rayCastHit, rayRange, pickupLayerMask))
            {
                if (rayCastHit.transform.TryGetComponent(out _trashPieceSCR)) //checking if layer has script
                {
                    _trashPieceSCR.GrabObject(objectHoldPointTransform);
                }
            }
            isHolding = true;
        }

        else
        {
            _trashPieceSCR.DropObject();
            _trashPieceSCR = null;
            isHolding = false;
        }
    }

    public void ObjectThrow()
    {
        if (isHolding)
        {
            _trashPieceSCR.DropObject();
            _trashPieceSCR.trashRB.AddForce(objectHoldPointTransform.forward * throwForce * Time.deltaTime, ForceMode.Impulse);
        }
    }
}