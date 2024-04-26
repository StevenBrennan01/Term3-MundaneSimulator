using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("= Movement =")]
    [Space(10)]

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float playerDrag = 6f; //drag to stop player speeding up

    [SerializeField]
    private float movementMultiplier = 10f; //increases speed to mitigate drag

    private Rigidbody rb;

    [HideInInspector] public Vector2 movDir;

    private Vector3 moveDirection;

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
        rb.AddForce(moveDirection * moveSpeed * movementMultiplier, ForceMode.Acceleration);
    }
}