using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private int currentScore;

    [SerializeField]
    private TMP_Text quotaValueText;

    private void Start()
    {
        currentScore = 0;
        quotaValueText.text = " : " + currentScore;
    }

    public void IncreaseQuota(int ScoreToAdd)
    {
        currentScore += ScoreToAdd;
        quotaValueText.text = ": " + currentScore; ;
    }
}
