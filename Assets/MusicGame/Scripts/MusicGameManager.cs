using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngineInternal;

public class MusicGameManager : MonoBehaviour
{
    public bool startPlaying;

    public BeatScroller theBS;

    public int currentScore;
    public int scorePerNote = 100;

    public Text scoreText;
    public GameObject _EndGameUI;





    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;


                
            }
        }
    }
    /*public void PlusScore()
    {
        currentScore += scorePerNote;
        scoreText.text = "Score : " + currentScore;
    }*/


    public void NoteHit()
    {
        Debug.Log("Hit On Time");
        currentScore += scorePerNote;
        scoreText.text = "Score : " + currentScore;

    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
    }

    public void EndGame()
    {
        _EndGameUI.SetActive(true);
        _EndGameUI.transform.Find("FinalScore").GetComponent<TMP_Text>().text = "Final Score: " + currentScore;

    }
}

