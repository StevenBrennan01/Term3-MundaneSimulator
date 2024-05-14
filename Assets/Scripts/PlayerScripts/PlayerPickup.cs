using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    private TrashPiece _trashPieceSCR;

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
        if (_trashPieceSCR == null) //player is NOT currently holding an object
        {
            if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out rayCastHit, rayRange, pickupLayerMask))
            {
                if (rayCastHit.transform.TryGetComponent(out _trashPieceSCR)) //Checks if hit layer has _trashPieceSCR
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
            Rigidbody trashRB = _trashPieceSCR.trashRB;

            //Returns gravity to object and throws Trash
            _trashPieceSCR.DropObject();
            trashRB.AddForce(objectHoldPointTransform.forward * objectThrowForce * Time.deltaTime, ForceMode.Impulse);

            //Spins object when thrown
            Vector3 randAngularVelocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * objectSpinForce * Time.deltaTime;
            trashRB.angularVelocity = randAngularVelocity;
        }
    }
}