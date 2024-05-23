using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickableObject : MonoBehaviour
{
    private ScoreManager _scoreManagerSCR;
    private UIManager _uiManagerSCR;
    private GameManager _gameManagerSCR;

    private Transform objectHoldPointTransform;
    private Collider objectCollider;

    [HideInInspector] public Rigidbody objectRB;
    [SerializeField] private int objectValue;

    #region Inspector Header & Spacing
    [Header("= Pickable Object Item List =")]
    [Space(15)]
    #endregion

    [SerializeField] private GameObject footballItem;
    [Space(15)]

    [SerializeField] private GameObject[] binTrash;

    private void Awake()
    {
        _gameManagerSCR = GameObject.FindObjectOfType<GameManager>();
        _uiManagerSCR = GameObject.FindObjectOfType<UIManager>();
        _scoreManagerSCR = GameObject.FindGameObjectWithTag("GM").GetComponent<ScoreManager>();

        objectRB = GetComponent<Rigidbody>();
        objectCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        bool trashCollectionMet = false;
        bool objectCollectionMet = false;

        if (other.gameObject.tag == "trashCollect")
        {
            foreach (GameObject trashItem in binTrash)
            {
                if (trashItem != null && trashItem.GetInstanceID() == this.gameObject.GetInstanceID())
                {
                    _scoreManagerSCR.IncreaseQuota(objectValue);
                    trashCollectionMet = true;
                    Destroy(this.gameObject);
                    break;
                }
            }
        }

        if (other.gameObject.tag == "objectCollect" && gameObject == footballItem)
        {
            _scoreManagerSCR.IncreaseQuota(objectValue);
            objectCollectionMet = true;
            Destroy(this.gameObject);
        }

        if (!trashCollectionMet && !objectCollectionMet)
        {
            _gameManagerSCR.DisableWrongItemUI();
            Destroy(this.gameObject);
        }
    }

    #region ObjectInteraction
    public void GrabObject(Transform objectGrabPointTransform)
    {
        this.objectHoldPointTransform = objectGrabPointTransform;
        objectRB.useGravity = false; //disables the trash from falling
        objectCollider.enabled = false; //disables collider when held
    }

    public void DropObject()
    {
        this.objectHoldPointTransform = null;
        objectRB.useGravity = true;
        objectCollider.enabled = true;  
    }

    private void FixedUpdate()
    {
        if (objectHoldPointTransform != null)
        {
            float lerpValue = 20f;

            Vector3 newPosition = Vector3.Lerp(transform.position, objectHoldPointTransform.position, Time.deltaTime * lerpValue);
            transform.rotation = objectHoldPointTransform.rotation;
            transform.Rotate(0, -90, 0);
            objectRB.MovePosition(newPosition);
        }
    }
    #endregion
}

