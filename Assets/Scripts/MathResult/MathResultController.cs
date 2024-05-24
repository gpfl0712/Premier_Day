using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private string currentstory;
    void Start()
    {
        // PlayerPrefs????????????釉띾쐞????????⑸츩?筌뤾쑬?????깆젧
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Final Score: " + finalScore.ToString();
        currentstory=PlayerPrefs.GetString("CurrentStory");
    }

    // ?뺢퀗???????????筌뤾쑵???濡ル츎 嶺뚮∥?꾥땻??
    public void GoToMainStory()
    {
        // MainStory2 ?????뿉??????
        SceneManager.LoadScene("SameScene");
        
    }
}
