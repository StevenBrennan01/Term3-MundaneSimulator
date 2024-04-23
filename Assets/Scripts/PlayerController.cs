using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [Header("= Movement =")]
    [Space(10)]

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float playerDrag = 6f; //drag to stop player speeding up

    [SerializeField]
    private float movementMultiplier = 10f; //increases speed to mitigate drag

    private float horizontalMovement;
    private float verticalMovement;

    private Rigidbody rb;

    Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //physics wont affect player rotation
    }

    private void Update()
    {
        MyInput();
        rb.drag = playerDrag;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = (transform.forward * verticalMovement + transform.right * horizontalMovement).normalized;
        //using vertical before horizontal fixes diagonal movement? (why?)
    }

    private void MovePlayer()
    {
        rb.AddForce(moveDirection * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }
}