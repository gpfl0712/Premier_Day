using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultController1 : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private string currentstory;
    void Start()
    {
        // PlayerPrefs?????????????됰씭??????????몄릇?嶺뚮ㅎ??????源놁젳
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Final Score: " + finalScore.ToString();
        currentstory=PlayerPrefs.GetString("CurrentStory");
    }

    // ?類????????????嶺뚮ㅎ????嚥▲꺂痢?癲ル슢??袁λ빝??
    public void GoToMainStory()
    {
        // MainStory2 ?????肉??????
        SceneManager.LoadScene("oh'");
        
    }
}
