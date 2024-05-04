using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private audioManager _audioManagerSCR;

    [SerializeField]
    private GameObject[] trashObjects;

    [SerializeField]
    private Transform[] spawnPositions;

    private int spawnAmount;

        [Header("= Spawn Values =")]
        [Header("(# of Trash spawned is random between min and max set)")]
        [Space(15)]

    [SerializeField]
    private int minToSpawn;

    [SerializeField]
    private int maxToSpawn;

    private void Awake()
    {
        if (trashObjects.Length == 0) Debug.LogError("No trash assigned, assign some in the inspector");
        if (spawnPositions.Length == 0) Debug.LogError("No spawn positions assigned");   
            
        _audioManagerSCR = GetComponent<audioManager>();
    }

    private void Start()
    {
        _audioManagerSCR.BackroundAmbience();
        SpawnTrash();
    }

    private void SpawnTrash()
    {
        spawnAmount = Random.Range(minToSpawn, maxToSpawn);
        // try and make it so that only 1 object is spawned at each position
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(trashObjects[Random.Range(0, trashObjects.Length)], spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position, Quaternion.identity);
        }
    }
}