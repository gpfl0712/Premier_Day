using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 珥덇린 ?ㅼ젙???꾩슂??寃쎌슦 ?ш린???ㅼ젙
    }

    // 踰꾪듉 ?대┃ ???몄텧?섎뒗 硫붿꽌??
    public void StartchoiceScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Choicesitting");
    }
}
