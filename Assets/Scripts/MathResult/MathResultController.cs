using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ResultController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // PlayerPrefs에서 점수를 불러와서 텍스트에 설정
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        scoreText.text = "Final Score: " + finalScore.ToString();
    }

    // 버튼 클릭 시 호출되는 메서드
    public void GoToMainStory()
    {
        // MainStory2 씬으로 이동
        SceneManager.LoadScene("MainStory2");
    }
}
