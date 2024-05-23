using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private PickableObject _pickableObjectSCR;

    [SerializeField] private LayerMask pickupLayerMask;

    #region Inspector Header & Spacing
    [Header("= Set Transforms =")]
    [Space(10)]
    #endregion

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectHoldPointTransform;

    #region Inspector Header & Spacing
    [Header("= Throw Values =")]
    [Space(10)]
    #endregion

    [SerializeField] private float objectThrowForce;
    [SerializeField] private float objectSpinForce;

    [HideInInspector] public bool isHolding = false;

    private float rayRange = 2.55f;
    private RaycastHit rayCastHit;

    public void ObjectInteract()
    {
        if (_pickableObjectSCR == null) //player is NOT holding an object
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out rayCastHit, rayRange, pickupLayerMask))
            {
                if (rayCastHit.transform.TryGetComponent(out _pickableObjectSCR))
                {
                    _pickableObjectSCR.GrabObject(objectHoldPointTransform);
                }
            }
            isHolding = true;
        }

        else
        {
            _pickableObjectSCR.DropObject();
            _pickableObjectSCR = null;
            isHolding = false;
        }
    }

    public void ObjectThrow()
    {
        if (isHolding)
        {
            Rigidbody objectRB = _pickableObjectSCR.objectRB;

            if (objectRB != null)
            {
                //Returns gravity to object and throws Trash
                _pickableObjectSCR.DropObject();
                objectRB.AddForce(objectHoldPointTransform.forward * objectThrowForce * Time.deltaTime, ForceMode.Impulse);

                //Spins object when thrown
                Vector3 randAngularVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * objectSpinForce * Time.deltaTime;
                objectRB.angularVelocity = randAngularVelocity;
            }
        }
    }
}