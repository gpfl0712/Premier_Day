using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndingController : MonoBehaviour
{
    private int totalscore;
    private int like;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI minigamescore;
    public TextMeshProUGUI total;
    private int minigame;
    public float typingSpeed = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        like = PlayerPrefs.GetInt("like", 0);
        minigame = PlayerPrefs.GetInt("FinalScore");
     /*   minigame += PlayerPrefs.GetInt("FinalScore_exe");
        minigame += PlayerPrefs.GetInt("FinalScore_music");*/

        totalscore = like + minigame;
        UpdateScoreText(); 
    }



    private void UpdateScoreText()
    {
        StartCoroutine(TypeText(scoreText, "호감도" + like.ToString()));
        StartCoroutine(TypeText(minigamescore, "미니게임점수 " + minigame.ToString()));
        StartCoroutine(TypeText(total, "총점수" + totalscore.ToString()));
    }
    private IEnumerator TypeText(TextMeshProUGUI textComponent, string text)
    {
        textComponent.text = "";
        foreach (char letter in text)
        {
            textComponent.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void restart()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
