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
        // ????影?력????몃쭫????源녾텛?????ル늉?? ????癲??? ??? ??棺堉?뤃??????????????ㅼ굣塋??饔낅떽???壤굿?戮㏐광??
        if (!bottomBar.isChoiceDisplayed)
        {
            // ?????繹먮굛???????깅즽癲?????????饔낅떽??????????????轅붽틓????????
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
        Debug.Log("雅?퍔瑗띰㎖?饔끸뫁臾???????덈틖");
        if (minigame == "Math")
        {
            SceneManager.LoadScene("MathGame");
        }
        if(minigame=="Exercise")
        {
            SceneManager.LoadScene("ExerciseGame");
        }
        if(minigame=="Math'")
        {
            SceneManager.LoadScene("MathGame'");
        }
        if(minigame=="Music")
        {
            SceneManager.LoadScene("MusicGame");
        }
    }

}
