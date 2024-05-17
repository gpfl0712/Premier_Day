using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static StoryScene;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;
    public GameObject choiceButtonPrefab; // 선택지 버튼 프리팹
    public Transform choicesContainer; // 선택지 컨테이너
    public BackgroundController backgroundController;
    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;
    public bool isChoiceDisplayed = false; // 선택지 표시 여부

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
        isChoiceDisplayed = false; // 선택지가 제거되었음을 표시
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
            choiceButton.onClick.AddListener(() => OnChoiceSelected(choice1)); // 델리게이트를 사용하여 메서드 호출
            Debug.Log("well done");
        }
        isChoiceDisplayed = true; // 선택지가 표시되었음을 표시
    }

    public void OnChoiceSelected(Choice choice)
    {
        Debug.Log("Choice selected: " + choice.text); // 선택지가 선택되었음을 로그에 출력
        if (choice.nextScene != null)
        {
            PlayScene(choice.nextScene);
            backgroundController.SwitchImage(choice.nextScene.background); // 배경 변경 요청
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
