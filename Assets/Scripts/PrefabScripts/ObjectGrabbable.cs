using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Transform objectGrabPointTransform;

    private Rigidbody trashBagRB;

    private Collider myCollider;

    [SerializeField]
    private int trashValue;

    private void Awake()
    {
        trashBagRB = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
    }

    public void GrabObject(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        trashBagRB.useGravity = false; //disables the trash from falling
        myCollider.enabled = false;
    }

    public void DropObject()
    {
        this.objectGrabPointTransform = null;
        trashBagRB.useGravity = true;
        myCollider.enabled = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpValue = 10f;

            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpValue); //lerps from world position to hand
            transform.rotation = objectGrabPointTransform.rotation;
            transform.Rotate(0, -90, 0);
            trashBagRB.MovePosition(newPosition);
        }
    }
}
