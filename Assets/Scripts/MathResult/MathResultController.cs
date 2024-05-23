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
        // PlayerPrefs?癒?퐣 ?癒?땾???븍뜄???????용뮞?紐꾨퓠 ??쇱젟
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Final Score: " + finalScore.ToString();
        currentstory=PlayerPrefs.GetString("CurrentStory");
    }

    // 甕곌쑵?????????紐꾪뀱??롫뮉 筌롫뗄苑??
    public void GoToMainStory()
    {
        // MainStory2 ???앮에???猷?
        SceneManager.LoadScene("SameScene");
        
    }
}
