using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/TrashValues", order = 1 )]

public class TrashValues : MonoBehaviour
{
    private ScoreManager scoreManager;

    [SerializeField]
    private int trashValue;

    private void Awake()
    {
        scoreManager.GetComponent<ScoreManager>();
    }

    

}
