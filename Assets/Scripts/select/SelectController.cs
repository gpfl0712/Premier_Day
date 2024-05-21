using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class SelectController : MonoBehaviour
{
    private string currentStory;
    private bool keyring = false;
    private bool mychou= false;
    private bool soccershoes = false;
    private bool brickbear = false;

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
        // ?댁쟾????λ맂 ?꾩씠???좏깮 ?뺣낫媛 ?덈뒗吏 ?뺤씤?섍퀬 媛?몄샂

    }

    public void OnkeyringClick()
    {
        keyring = true;
        PlayerPrefs.SetInt("keyring", keyring ? 1 : 0);
        Debug.Log("keyring Selected: " + keyring);
    }

    public void OnmychouClick()
    {
         mychou= true;
        PlayerPrefs.SetInt("mychou", mychou ? 1 : 0);
        Debug.Log("mychou Selected: " + mychou);
    }

    public void OnsoccershoesClick()
    {
        soccershoes = true;
        PlayerPrefs.SetInt("soccershoes", soccershoes ? 1 : 0);
        Debug.Log("soccershoes Selected: " + soccershoes);
    }
    public void OnbrickbearClick()
    {
        brickbear = true;
        PlayerPrefs.SetInt("brickbear", brickbear ? 1 : 0);
        Debug.Log("brickbear Selected: " + brickbear);
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
