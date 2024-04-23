using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]
    private LayerMask pickableLayerMask;

    [SerializeField]
    private Transform playerCameraTransform;

    [SerializeField]
    private float hitRange = 2f;

    private RaycastHit hit;


    private void Update()
    {
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * hitRange, Color.blue);
        if (Physics.Raycast
            (playerCameraTransform.position, 
            playerCameraTransform.forward, 
            out hit, hitRange, 
            pickableLayerMask))
        {
            //do something (E to pickup)
        }
    }
   
 }
