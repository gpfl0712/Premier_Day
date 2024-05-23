using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectController : MonoBehaviour
{
    private string currentStory;
    private bool keyring = false;
    private bool mychou = false;
    private bool soccershoes = false;
    private bool brickbear = false;
    private int selectedCount = 0; // 선택된 아이템의 수를 추적하는 변수

    public Image keyringImage;
    public Image mychouImage;
    public Image soccershoesImage;
    public Image brickbearImage;

    // Start is called before the first frame update
    void Start()
    {
        currentStory = PlayerPrefs.GetString("CurrentStory");
        Debug.Log("Current Story: " + currentStory);
        keyring = PlayerPrefs.GetInt("keyring", 0) == 1;
        mychou = PlayerPrefs.GetInt("mychou", 0) == 1;
        soccershoes = PlayerPrefs.GetInt("soccershoes", 0) == 1;
        brickbear = PlayerPrefs.GetInt("brickbear", 0) == 1;
        Debug.Log("Initial keyring: " + keyring);
        Debug.Log("Initial mychou: " + mychou);
        Debug.Log("Initial soccershoes: " + soccershoes);
        Debug.Log("Initial brickbear: " + brickbear);

        // 초기 상태에 따라 이미지를 설정
        keyringImage.gameObject.SetActive(keyring);
        mychouImage.gameObject.SetActive(mychou);
        soccershoesImage.gameObject.SetActive(soccershoes);
        brickbearImage.gameObject.SetActive(brickbear);

        // 선택된 아이템 수 갱신
        
    }

    public void OnkeyringClick()
    {
        if (!keyring && selectedCount < 2) // 아직 선택되지 않았고, 선택된 아이템이 2개 미만일 때만
        {
            keyring = true;
            PlayerPrefs.SetInt("keyring", keyring ? 1 : 0);
            Debug.Log("keyring Selected: " + keyring);
            keyringImage.gameObject.SetActive(keyring);
            selectedCount++;
        }
    }

    public void OnmychouClick()
    {
        if (!mychou && selectedCount < 2) // 아직 선택되지 않았고, 선택된 아이템이 2개 미만일 때만
        {
            mychou = true;
            PlayerPrefs.SetInt("mychou", mychou ? 1 : 0);
            Debug.Log("mychou Selected: " + mychou);
            mychouImage.gameObject.SetActive(mychou);
            selectedCount++;
        }
    }

    public void OnsoccershoesClick()
    {
        if (!soccershoes && selectedCount < 2) // 아직 선택되지 않았고, 선택된 아이템이 2개 미만일 때만
        {
            soccershoes = true;
            PlayerPrefs.SetInt("soccershoes", soccershoes ? 1 : 0);
            Debug.Log("soccershoes Selected: " + soccershoes);
            soccershoesImage.gameObject.SetActive(soccershoes);
            selectedCount++;
        }
    }

    public void OnbrickbearClick()
    {
        if (!brickbear && selectedCount < 2) // 아직 선택되지 않았고, 선택된 아이템이 2개 미만일 때만
        {
            brickbear = true;
            PlayerPrefs.SetInt("brickbear", brickbear ? 1 : 0);
            Debug.Log("brickbear Selected: " + brickbear);
            brickbearImage.gameObject.SetActive(brickbear);
            selectedCount++;
        }
    }

    public void HandleStorySelection()
    {
        switch (currentStory)
        {
            case "Choi":
                Debug.Log("Selected story: Choi");
                Debug.Log("Brickbear" + brickbear);
                SceneManager.LoadScene("Mainstory_choi");
                break;
            case "Han":
                Debug.Log("Selected story: Han");
                SceneManager.LoadScene("Mainstory_Han");
                break;
            case "Kang":
                Debug.Log("Selected story: Kang");
                SceneManager.LoadScene("Mainstory_kang");
                break;
            case "Oh":
                Debug.Log("Selected story: Oh");
                SceneManager.LoadScene("Mainstory_oh");
                break;
            default:
                Debug.Log("Unknown story selected");
                break;
        }
    }
}
