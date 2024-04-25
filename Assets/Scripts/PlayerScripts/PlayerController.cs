using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public Vector2 movDir;

    [Header("= Movement =")]
    [Space(10)]

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float playerDrag = 6f; //drag to stop player speeding up

    [SerializeField]
    private float movementMultiplier = 10f; //increases speed to mitigate drag

    private Rigidbody rb;

    Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //physics wont affect player rotation
    }

    private void Update()
    {
        rb.drag = playerDrag;
    }

    public void Walk()
    {
        moveDirection = (transform.forward * movDir.y + transform.right * movDir.x).normalized;
        //using vertical before horizontal fixes diagonal movement, 
        rb.AddForce(moveDirection * moveSpeed * movementMultiplier, ForceMode.Acceleration);
        
    }
}