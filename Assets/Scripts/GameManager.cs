using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private audioManager _audioManagerSCR;

    #region Inspector Header & Spacing
    [Header("= Object Spawner =")]
    [Space(15)]
    #endregion

    [SerializeField] private GameObject[] trashObjects;
    [SerializeField] private Transform[] spawnPositions;

    private int spawnAmount;

    #region Inspector Header & Spacing
    [Header("= Spawn Values =")]
    [Header("(# of Trash spawned is random between min and max set)")]
    [Space(15)]
    #endregion

    [SerializeField] private int minToSpawn;
    [SerializeField] private int maxToSpawn;

    private void Awake()
    {
        if (trashObjects.Length == 0) Debug.LogError("No trash assigned, assign some in the inspector");
        if (spawnPositions.Length == 0) Debug.LogError("No spawn positions assigned in inspector");

        _audioManagerSCR = GetComponent<audioManager>();
    }

    private void Start()
    {
        SpawnTrash();
        _audioManagerSCR.BackroundAmbience();
    }

    private void SpawnTrash()
    {
        int spawnAmount = Random.Range(minToSpawn, maxToSpawn);

        // Randomly shuffles through the spawnPositions Array
        List<Transform> randPositions = spawnPositions.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < spawnAmount; i++)
        {
            if (i >= randPositions.Count) break; // Allows only 1 to be spawned per Position

            Transform spawnPosition = randPositions[i];
            GameObject trashObject = trashObjects[Random.Range(0, trashObjects.Length)];
            Instantiate(trashObject, spawnPosition.position, Quaternion.identity);
        }
    }
}