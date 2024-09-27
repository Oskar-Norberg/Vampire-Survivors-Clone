using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundTimerUI : MonoBehaviour
{
    [SerializeField] private string prependText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private RoundTimer roundTimer;

    private void Update()
    {
        float time = roundTimer.GetTimeInSeconds();
        int minutes = Mathf.FloorToInt(time / 60.0f);
        int seconds = Mathf.FloorToInt(time % 60.0f);
        timerText.text = prependText + " " + minutes + ":" + seconds;
    }
}
