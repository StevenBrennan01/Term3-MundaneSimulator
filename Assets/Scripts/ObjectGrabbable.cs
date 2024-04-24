using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{

    private Rigidbody trashBagRB;
    private Transform objectGrabPointTransform;

    private void Awake()
    {
        trashBagRB = GetComponent<Rigidbody>();
    }

    public void GrabObject(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        trashBagRB.useGravity = false; //disables the trash from falling
    }

    public void DropObject()
    {
        this.objectGrabPointTransform = null;
        trashBagRB.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpValue = 10f;
            Vector3 moveToNewPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpValue); //lerps from world position to hand
            trashBagRB.MovePosition(objectGrabPointTransform.position);
        }
    }
}
