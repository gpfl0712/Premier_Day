using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BottomBarController : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;
    private enum State
    {
        PLAYING,COMPLETED
    }
    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }
    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        personNameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
        personNameText.color = currentScene.sentences[sentenceIndex].speaker.textColor;
     

    }
    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }
    // Update is called once per frame
 private IEnumerator TypeText(string text)
    {
        barText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            barText.text += text[wordIndex];
            yield return new WaitForSeconds(0.05f);
            if (++wordIndex == text.Length)
            {
                state=State.COMPLETED;
                break;
            }
        }
    }
}
