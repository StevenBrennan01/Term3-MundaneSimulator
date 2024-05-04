using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashPiece : MonoBehaviour
{
    private Transform objectGrabPointTransform;
    private Rigidbody trashBagRB;
    private Collider myCollider;

    private ScoreManager _scoreManagerSCR;

    [SerializeField]
    private int objectValue;

    private void Awake()
    {
        trashBagRB = GetComponent<Rigidbody>(); //for getting components and scripts on the gameobject
        myCollider = GetComponent<Collider>();

        _scoreManagerSCR = FindObjectOfType<ScoreManager>(); //for getting scripts located elsewhere in the project (memory or gameobject)

        //_scoreManagerSCR = GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreManager>(); //for getting scripts located elsewhere, but explicitly showing where it would be found.
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
        this.objectGrabPointTransform = objectGrabPointTransform;
        trashBagRB.useGravity = false; //disables the trash from falling
        myCollider.enabled = false; //disables collider when held
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
            float lerpValue = 20f;

            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpValue); //lerps from world position to hand
            transform.rotation = objectGrabPointTransform.rotation;
            transform.Rotate(0, -90, 0);
            trashBagRB.MovePosition(newPosition);
        }
    }
    #endregion
}

