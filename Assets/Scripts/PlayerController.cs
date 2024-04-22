using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [Header("= Movement =")]
    [Space(10)]

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float playerDrag = 6f; //fixes drag against floor
    [SerializeField] private float movementMultiplier = 10f; //increases speed alongside drag

    private float horizontalMovement;
    private float verticalMovement;

    private Rigidbody rb;

    Vector3 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
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

        //moveDirection += moveDirection.normalized;
        moveDirection = (transform.right * horizontalMovement + transform.forward * verticalMovement * Time.deltaTime); 
    }

    private void MovePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }
}
