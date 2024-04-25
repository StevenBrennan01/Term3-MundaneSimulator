using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickupLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private Transform objectGrabPointTransform;

    [SerializeField]
    private float rayRange = 2f;

    private ObjectGrabbable objectGrabbable;

    private RaycastHit raycastHit;

    private void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * rayRange, Color.magenta);

        //ObjectInteract();
    }

    #region RayCast
    public void ObjectInteract()
    {
        Debug.Log("Interact Fired");
        if (objectGrabbable == null) //if player is not currently holding an object
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out raycastHit, rayRange, pickupLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out objectGrabbable)) //only going to be using one LayerMask anyway?
                {
                    objectGrabbable.GrabObject(objectGrabPointTransform);
                }
            }
        }
        else //player is currently holding an object
        {
            objectGrabbable.DropObject();
            objectGrabbable = null;
        }
    }
    #endregion
}
