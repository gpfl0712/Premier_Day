using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    int score = 0;
    public TMP_Text _Score;
    public UITimer _UITimer;
    public GameObject _EndGameUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        _Score.text = "점수: " + ++score;
    }

    public void AddTime(float time)
    {
        _UITimer.AddTime(time);
    }

    public void EndGame()
    {
        _EndGameUI.SetActive(true);
        _EndGameUI.transform.FindChild("FinalScore").GetComponent<TMP_Text>().text = "Final Score: " + score;
    }

    public void NextScene()
    {
        SceneManager.LoadScene("ExerciseGameResult");
    }
}
