using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("= Movement =")]
    [Space(10)]

    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private float playerDrag; //Drag to stop player speeding up
    [SerializeField] private float movementMultiplier; //Increases speed to mitigate drag

    private Rigidbody rb;

    [HideInInspector] public Vector2 movDir;

    private Vector3 moveDirectionNormalized;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; //So physics won't affect player rotation
    }

    private void Update()
    {
        rb.drag = playerDrag;
    }

    public void Walk()
    {
        moveDirectionNormalized = (transform.forward * movDir.y + transform.right * movDir.x).normalized;
        rb.AddForce(moveDirectionNormalized * moveSpeed * movementMultiplier * Time.deltaTime, ForceMode.Acceleration);
    }
}