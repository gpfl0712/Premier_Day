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
        // ???ャ뀕?얜ŉ異?堉온??좊읈? ??筌?六??? ??? ?濡ろ뜑???????????곸죷 癲ル슪?ｇ몭??
        if (!bottomBar.isChoiceDisplayed)
        {
            // ????됱뱻???⑤８痢??????獒?癲ル슢???????????嶺뚮Ĳ?됮?
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
        Debug.Log("誘몃땲寃뚯엫?ㅽ뻾");
        if (minigame == "Math")
        {
            SceneManager.LoadScene("MathGame");
        }

    }

}
