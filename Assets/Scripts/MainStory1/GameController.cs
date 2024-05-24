using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (!bottomBar.isChoiceDisplayed)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (bottomBar.IsCompleted())
                {
                    if (bottomBar.IsLastSentence())
                    {
                        if (currentScene.IsEnding == true)
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

    public void UpdateCurrentScene(StoryScene newScene)
    {
        currentScene = newScene;
    }

    private void LoadMiniGame(string minigame)
    {
        Debug.Log("미니게임 로드 중");
        if (minigame == "Math")
        {
            SceneManager.LoadScene("MathGame");
        }
        if (minigame == "Exercise")
        {
            SceneManager.LoadScene("ExerciseGame");
        }
        if (minigame == "Math2")
        {
            SceneManager.LoadScene("MathGame2");
        }
        if (minigame == "Music")
        {
            SceneManager.LoadScene("MusicGame");
        }
    }
}
