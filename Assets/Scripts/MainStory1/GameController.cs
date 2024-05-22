using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static StoryScene;

public class GameController : MonoBehaviour
{
    public StoryScene currentScene;
    public BottomBarController bottomBar;
    public BackgroundController backgroundController;

    void Start()
    {
        bottomBar.PlayScene(currentScene);
        backgroundController.SetImage(currentScene.background);
    }

    void Update()
    {
        // ????ｋ??쑩됬빊??됱삩???醫딆쓧? ??嶺?筌??? ??? ?嚥▲굧????????????怨몄７ ?꿔꺂??節뉖き??
        if (!bottomBar.isChoiceDisplayed)
        {
            // ?????깅굳????ㅿ폍筌?????????꿔꺂????????????癲ル슢캉????
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (bottomBar.IsCompleted())
                {
                    if (bottomBar.IsLastSentence())
                    {
                        if(currentScene.IsEnding==true)
                        {
                            SceneManager.LoadScene("Ending");
                        }
                        if (!string.IsNullOrEmpty(currentScene.minigame))
                        {
                            LoadMiniGame(currentScene.minigame);
                        }
                        currentScene = currentScene.nextScene;
                        bottomBar.PlayScene(currentScene);
                        backgroundController.SwitchImage(currentScene.background);
                    }
                   
                }
                bottomBar.PlayNextSentence();
            }
        }
    }
    private void LoadMiniGame(string minigame)
    {
        Debug.Log("沃섎챶?꿨칰??뿫??쎈뻬");
        if (minigame == "Math")
        {
            SceneManager.LoadScene("MathGame");
        }
        if(minigame=="Launch")
        {
            SceneManager.LoadScene("LaunchGame");
        }

    }

}
