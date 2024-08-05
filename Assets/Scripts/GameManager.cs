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
    private UIManager _uiManagerSCR;

    #region Inspector Header & Spacing
    [Header("= Object Spawner =")]
    [Space(15)]
    #endregion

    [SerializeField] private GameObject[] trashObjects;
    [SerializeField] private Transform[] spawnPositions;

    #region Inspector Header & Spacing
    [Header("= Spawn Values =")]
    [Header("(# of Trash spawned is random between min and max set)")]
    [Space(15)]
    #endregion

    [SerializeField] private int minToSpawn;
    [SerializeField] private int maxToSpawn;

    private void Awake()
    {
        _uiManagerSCR = FindObjectOfType<UIManager>();
        _audioManagerSCR = GetComponent<audioManager>();

        if (trashObjects.Length == 0) Debug.LogError("No trash assigned, assign some in the inspector");
        if (spawnPositions.Length == 0) Debug.LogError("No spawn positions assigned in inspector");
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
        List<Transform> shufflePositions = spawnPositions.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < spawnAmount; i++)
        {
            if (i >= shufflePositions.Count) break; // Allows only 1 to be spawned per Position

            Transform spawnPosition = shufflePositions[i];
            GameObject trashObject = trashObjects[Random.Range(0, trashObjects.Length)];
            Instantiate(trashObject, spawnPosition.position, Quaternion.identity);
        }
    }

    public void DisableWrongItemUI()
    {
        _uiManagerSCR.wrongItemUI.SetActive(true);

        _audioManagerSCR.horrorAudio.Play();

        Coroutine wrongItemTimer_CR;
        wrongItemTimer_CR = StartCoroutine(CR_DisableWrongItemUI());
    }

    IEnumerator CR_DisableWrongItemUI()
    {
        yield return new WaitForSeconds(4);
        _uiManagerSCR.wrongItemUI.SetActive(false);
    }
}