using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour
{

    public bool isSwitched = false;
    public Image background1;
    public Image background2;
    public Animator animator;

    public void SwitchImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background2.sprite = sprite;
            animator.SetTrigger("SwitchFirst");
            Debug.Log("SwitchImage: SwitchFirst trigger set.");
        }
        else
        {
            background1.sprite = sprite;
            animator.SetTrigger("SwitchSecond");
            Debug.Log("SwitchImage: SwitchSecond trigger set.");
        }
        isSwitched = !isSwitched;
    }

    public void SetImage(Sprite sprite)
    {
        if (!isSwitched)
        {
            background1.sprite = sprite;
            Debug.Log("SetImage: background1 image set.");
        }
        else
        {
            background2.sprite = sprite;
            Debug.Log("SetImage: background2 image set.");
        }
    }
}
