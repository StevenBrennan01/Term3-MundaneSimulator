using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private int currentScore;

    [SerializeField]
    private TMP_Text quotaValueText;

    [SerializeField]
    private int quotaGoalValue;

    private void Awake()
    {
        currentScore = 0;
        quotaGoalValue = 50;

        quotaValueText.text = "Quota: " + currentScore + " / 50";
    }

    private void FixedUpdate()
    {
        WinStatement();
    }

    public void IncreaseQuota(int _scoreToAdd)
    {
        currentScore += _scoreToAdd;
        quotaValueText.text = "Quota: " + currentScore + " / 50";
    }

    private void WinStatement()
    {
        if (currentScore >= quotaGoalValue)
        {
            // win scene or display UI here
            Debug.Log("You have won the game!");
        }
    }
}
