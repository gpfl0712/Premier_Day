using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 초기 설정이 필요한 경우 여기서 설정
    }

    // 버튼 클릭 시 호출되는 메서드
    public void StartchoiceScene()
    {
        SceneManager.LoadScene("choiceScene");
    }
}
