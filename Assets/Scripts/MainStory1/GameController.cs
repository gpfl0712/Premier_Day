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
        // ????節떷???⑸맟鍮???깆궔????ル봿?? ??癲?嶺??? ??? ??β뼯援?????????????⑤챷竊??轅붽틓??影?뽧걤??
        if (!bottomBar.isChoiceDisplayed)
        {
            // ?????源낃뎨?????욱룏嶺?????????轅붽틓?????????????꿔꺂??틝?????
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
        Debug.Log("亦껋꼶梨?轅⑥물??肉???덈뺄");
        if (minigame == "Math")
        {
            SceneManager.LoadScene("MathGame");
        }
        if(minigame=="Exercise")
        {
            SceneManager.LoadScene("ExerciseGame");
        }
        if(minigame=="Math2")
        {
            SceneManager.LoadScene("MathGame2");
        }
        if(minigame=="Music")
        {
            SceneManager.LoadScene("MusicGame");
        }
    }

}
