using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingController : MonoBehaviour
{
    private int like;
    public TextMeshProUGUI scoreText; // TextMeshProUGUI 객체를 public으로 선언하여 Unity 에디터에서 할당 가능하게 합니다.

    // Start is called before the first frame update
    void Start()
    {
        like = PlayerPrefs.GetInt("like", 0); // like 점수를 PlayerPrefs에서 가져옵니다.
        UpdateScoreText(); // 시작할 때 점수를 업데이트합니다.
    }



    private void UpdateScoreText()
    {
        scoreText.text = "Like: " + like.ToString(); // 점수를 텍스트로 변환하여 TextMeshProUGUI 객체에 설정합니다.
    }
}
