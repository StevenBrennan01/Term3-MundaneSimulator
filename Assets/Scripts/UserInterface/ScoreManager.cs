using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private UIManager _uiManagerSCR;

    [SerializeField] private TMP_Text quotaValueText;

    [SerializeField] private int quotaGoalValue;
    [HideInInspector] private int currentScore;

    private void Awake()
    {
        _uiManagerSCR = FindObjectOfType<UIManager>();

        currentScore = 0;

        quotaValueText.text = "Quota: " + currentScore + " / " + quotaGoalValue;
    }

    public void IncreaseQuota(int _scoreToAdd)
    {
        currentScore += _scoreToAdd;
        quotaValueText.text = "Quota: " + currentScore + " / " + quotaGoalValue;

        if (currentScore >= quotaGoalValue)
        {
            _uiManagerSCR.WinStatement();
        }
    }

}
