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
        // ??ルㅎ臾며춯?뼿?띠럾? ??戮?뻣??? ??? ?롪퍔?????異????놁졑 嶺뚳퐣瑗??
        if (!bottomBar.isChoiceDisplayed)
        {
            // ???덉쓡??怨룸츩 ?????裕?嶺뚮씭??????????筌먦끉逾?
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (bottomBar.IsCompleted())
                {
                    if (bottomBar.IsLastSentence())
                    {

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
        Debug.Log("미니게임실행");
        if (minigame == "Math")
        {
            SceneManager.LoadScene("MathGame");
        }

    }

}
