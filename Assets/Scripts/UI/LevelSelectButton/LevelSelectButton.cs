using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    [SerializeField] private TextMeshProUGUI buttonText;

    private void OnEnable()
    {
        SetButtonText();
    }

    private void SetButtonText()
    {
        if (HighscoreManager.HasPreviousScore(sceneName))
        {
            float highScore = HighscoreManager.GetHighscore(sceneName);
            int minutes = Mathf.FloorToInt(highScore / 60);
            int seconds = Mathf.FloorToInt(highScore - minutes * 60);
            string timeString = $"{minutes:00}:{seconds:00}";
            buttonText.text = sceneName + " - " + timeString; 
        }
        else
        {
            buttonText.text = sceneName;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}
