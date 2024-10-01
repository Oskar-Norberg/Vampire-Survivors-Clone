using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundTimerUI : MonoBehaviour
{
    [SerializeField] private RoundTimer roundTimer;
    
    [SerializeField] private string prependText;
    
    [SerializeField] private TextMeshProUGUI timerText;

    private void Update()
    {
        timerText.text = prependText + " " + roundTimer.GetFormattedString();
    }
}
