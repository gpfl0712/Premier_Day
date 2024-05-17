using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        // 선택지가 표시되지 않은 경우에만 입력 처리
        if (!bottomBar.isChoiceDisplayed)
        {
            // 스페이스 키 또는 마우스 클릭 확인
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (bottomBar.IsCompleted())
                {
                    if (bottomBar.IsLastSentence())
                    {
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
}
