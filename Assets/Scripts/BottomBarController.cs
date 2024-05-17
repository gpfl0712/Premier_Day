using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static StoryScene;
using UnityEngine.SceneManagement;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;
    public GameObject choiceButtonPrefab; // ?좏깮吏 踰꾪듉 ?꾨━??
    public Transform choicesContainer; // ?좏깮吏 而⑦뀒?대꼫
    public BackgroundController backgroundController;
    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;
    public bool isChoiceDisplayed = false; // ?좏깮吏 ?쒖떆 ?щ?

    private enum State
    {
        PLAYING, COMPLETED
    }

    public void PlayScene(StoryScene scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }
   

    public void PlayNextSentence()
    {
        if (sentenceIndex + 1 < currentScene.sentences.Count)
        {
            sentenceIndex++;
            StopAllCoroutines();
            ClearChoices();
            var sentence = currentScene.sentences[sentenceIndex];
            if (sentence.choices != null && sentence.choices.Count > 0)
            {
                ShowChoices(sentence.choices);
            }
            else
            {
                StartCoroutine(TypeText(sentence.text));
                personNameText.text = sentence.speaker.speakerName;
                personNameText.color = sentence.speaker.textColor;
            }
           
        }
    }
 

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
                state = State.COMPLETED;
                break;
            }
        }
    }

    private void ClearChoices()
    {
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }
        isChoiceDisplayed = false; // ?좏깮吏媛 ?쒓굅?섏뿀?뚯쓣 ?쒖떆
    }

    private void ShowChoices(List<Choice> choices)
    {
        foreach (var choice in choices)
        {
            GameObject choiceButtonObject = Instantiate(choiceButtonPrefab, choicesContainer);
            TextMeshProUGUI choiceText = choiceButtonObject.GetComponentInChildren<TextMeshProUGUI>();
            choiceText.text = choice.text;
            Choice choice1 = choice;
            Button choiceButton = choiceButtonObject.GetComponent<Button>();
            choiceButton.onClick.AddListener(() => OnChoiceSelected(choice1)); // ?몃━寃뚯씠?몃? ?ъ슜?섏뿬 硫붿꽌???몄텧
            Debug.Log("well done");
        }
        isChoiceDisplayed = true; // ?좏깮吏媛 ?쒖떆?섏뿀?뚯쓣 ?쒖떆
    }

    public void OnChoiceSelected(Choice choice)
    {
        Debug.Log("Choice selected: " + choice.text); // ?좏깮吏媛 ?좏깮?섏뿀?뚯쓣 濡쒓렇??異쒕젰
        if (choice.nextScene != null)
        {
            PlayScene(choice.nextScene);
            backgroundController.SwitchImage(choice.nextScene.background); // 諛곌꼍 蹂寃??붿껌
        }
        else
        {
            PlayNextSentence();
        }
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }
}
