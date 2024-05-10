using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class TrashPiece : MonoBehaviour
{
    private Transform objectHoldPointTransform;
    private Collider myCollider;
    private Rigidbody trashBagRB;

    private ScoreManager _scoreManagerSCR;

    [SerializeField]
    private int objectValue;

    private void Awake()
    {
        trashBagRB = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();

        _scoreManagerSCR = GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreManager>(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "trashCollect")
        {
            _scoreManagerSCR.IncreaseQuota(objectValue);
            Destroy(this.gameObject);
        }
    }

    #region ObjectInteraction
    public void GrabObject(Transform objectGrabPointTransform)
    {
        this.objectHoldPointTransform = objectGrabPointTransform;
        trashBagRB.useGravity = false; //disables the trash from falling
        myCollider.enabled = false; //disables collider when held
    }

    public void DropObject()
    {
        this.objectHoldPointTransform = null;
        trashBagRB.useGravity = true;
        myCollider.enabled = true;
    }

    private void FixedUpdate()
    {
        if (objectHoldPointTransform != null)
        {
            float lerpValue = 20f;

            Vector3 newPosition = Vector3.Lerp(transform.position, objectHoldPointTransform.position, Time.deltaTime * lerpValue); //lerps from world position to hand
            transform.rotation = objectHoldPointTransform.rotation;
            transform.Rotate(0, -90, 0);
            trashBagRB.MovePosition(newPosition);
        }
    }
    #endregion
}

