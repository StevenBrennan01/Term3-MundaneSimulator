using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class TrashPiece : MonoBehaviour
{
    private ScoreManager _scoreManagerSCR;

    private Transform objectHoldPointTransform;
    private Collider trashCollider;
    
    [HideInInspector] public Rigidbody trashRB;

    [SerializeField] private int trashValue;

    private void Awake()
    {
        trashRB = GetComponent<Rigidbody>();
        trashCollider = GetComponent<Collider>();

        _scoreManagerSCR = GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "trashCollect")
        {
            _scoreManagerSCR.IncreaseQuota(trashValue);
            Destroy(this.gameObject);
        }
    }

    #region ObjectInteraction
    public void GrabObject(Transform objectGrabPointTransform)
    {
        this.objectHoldPointTransform = objectGrabPointTransform;
        trashRB.useGravity = false; //disables the trash from falling
        trashCollider.enabled = false; //disables collider when held
    }

    public void DropObject()
    {
        this.objectHoldPointTransform = null;
        trashRB.useGravity = true;
        trashCollider.enabled = true;  
    }

    private void FixedUpdate()
    {
        if (objectHoldPointTransform != null)
        {
            float lerpValue = 20f;

            Vector3 newPosition = Vector3.Lerp(transform.position, objectHoldPointTransform.position, Time.deltaTime * lerpValue);
            transform.rotation = objectHoldPointTransform.rotation;
            transform.Rotate(0, -90, 0);
            trashRB.MovePosition(newPosition);
        }
    }
    #endregion
}

