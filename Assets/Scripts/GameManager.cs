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
    private int[] spawnCount;

    private void Start()
    {
        if (trashObjects.Length == 0) Debug.LogError("No trash assigned, assign some in the inspector");
        if (spawnPositions.Length == 0) Debug.LogError("No spawn positions assigned");
    }

    private void SpawnTrash()
    {
        Instantiate(trashObjects[Random.Range(0, spawnCount.Length)], spawnPositions[Random.Range(0, spawnPositions.Length)].position, Quaternion.identity);
    }



}
