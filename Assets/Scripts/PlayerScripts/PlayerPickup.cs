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

    private float rayRange = 2.5f;

    private ObjectGrabbable objectGrabbable;

    private RaycastHit raycastHit;

    private void Update()
    { // ==!!   remove update when game is complete   !!==
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * rayRange, Color.magenta);
    } // ==!!   remove update when game is complete   !!==

    public void ObjectInteract()
    {
        if (objectGrabbable == null) //player is not currently holding an object
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out raycastHit, rayRange, pickupLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out objectGrabbable))
                {
                    objectGrabbable.GrabObject(objectGrabPointTransform);
                }
            } 
        }
        else //player is holding an object
        {
            objectGrabbable.DropObject();
            objectGrabbable = null;
        }
    }
}