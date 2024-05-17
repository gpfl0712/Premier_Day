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
        // ?醫뤾문筌왖揶쎛 ??뽯뻻??? ??? 野껋럩??癒?춸 ??낆젾 筌ｌ꼶??
        if (!bottomBar.isChoiceDisplayed)
        {
            // ??쎈읂??곷뮞 ???癒?뮉 筌띾뜆????????類ㅼ뵥
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
                    else
                    {
                        bottomBar.PlayNextSentence();
                    }
                }
            }
        }
    }
    private void LoadMiniGame(string minigame)
    {
        if (minigame == "Math")
        {
            SceneManager.LoadScene("MathGame");
        }

    }

}
