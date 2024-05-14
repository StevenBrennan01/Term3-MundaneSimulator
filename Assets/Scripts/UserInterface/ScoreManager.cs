using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TMP_Text quotaValueText;

    [SerializeField] private int quotaGoalValue;

    private int currentScore;

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
