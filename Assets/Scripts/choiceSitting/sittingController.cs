using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SittingController : MonoBehaviour
{
    // ????ш낄援?????ш낄援η뵳?癲ル슢??袁λ빝??筌먲퐡??
    public void LoadMainStory_choi()
    {
        PlayerPrefs.SetString("CurrentStory","Choi");
        SceneManager.LoadScene("choiceScene");
    }

    public void LoadMainStory_Han()
    {
        PlayerPrefs.SetString("CurrentStory","Han");
        SceneManager.LoadScene("choiceScene");
    }

    public void LoadMainStory_kang()
    {
        PlayerPrefs.SetString("CurrentStory", "Kang");
        SceneManager.LoadScene("choiceScene");
    }

    public void LoadMainStory_oh()
    {
        PlayerPrefs.SetString("CurrentStory", "Oh");
        SceneManager.LoadScene("choiceScene");
    }
}
