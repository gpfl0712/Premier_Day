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
        // PlayerPrefs?먯꽌 ?먯닔瑜?遺덈윭????띿뒪?몄뿉 ?ㅼ젙
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Final Score: " + finalScore.ToString();
        currentstory=PlayerPrefs.GetString("CurrentStory");
    }

    // 踰꾪듉 ?대┃ ???몄텧?섎뒗 硫붿꽌??
    public void GoToMainStory()
    {
        // MainStory2 ?ъ쑝濡??대룞
        if(currentstory=="Choi")
        {
            SceneManager.LoadScene("MainStory2_choi");
        }
        if (currentstory == "Han")
        {
            SceneManager.LoadScene("MainStory2_han");
        }
        if (currentstory == "Oh")
        {
            SceneManager.LoadScene("MainStory2_oh");
        }
        if (currentstory == "Kang")
        {
            SceneManager.LoadScene("MainStory2_kang");
        }
        
    }
}
