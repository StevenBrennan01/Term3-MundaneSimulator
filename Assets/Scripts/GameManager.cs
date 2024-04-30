using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("= Trash Manager =")]
    [Space(15)]

    [SerializeField]
    private GameObject[] trashObjects;

    [SerializeField]
    private Transform[] spawnPositions;

    [SerializeField]
    private int spawnAmount;

    [SerializeField]
    private int randSpawnSpot;

    private void Start()
    {
        if (trashObjects.Length == 0) Debug.LogError("No trash assigned, assign some in the inspector");
        if (spawnPositions.Length == 0) Debug.LogError("No spawn positions assigned");
        

    }

    private void Update()
    {
        SpawnTrash();
    }

    private void SpawnTrash()
    {     
        randSpawnSpot = Random.Range(0, spawnPositions.Length);

        for (int i = 0; i < trashObjects.Length; i++)
        {
            Instantiate(trashObjects[i-1], spawnPositions[randSpawnSpot].transform.position, Quaternion.identity);
            //spawnAmount++;
        }
    }