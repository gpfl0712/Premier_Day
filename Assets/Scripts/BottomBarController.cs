using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomBarController : MonoBehaviour
{
    public TextMeshProUGUI barText;
    public TextMeshProUGUI personNameText;
    public GameObject choiceButtonPrefab; // 선택지 버튼 프리팹
    public Transform choicesContainer; // 선택지 버튼들을 담을 컨테이너

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;

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
        if (sentenceIndex < currentScene.sentences.Count - 1)
        {
            var sentence = currentScene.sentences[++sentenceIndex];
            StartCoroutine(TypeText(sentence.text));
            personNameText.text = sentence.speaker.speakerName;
            personNameText.color = sentence.speaker.textColor;

            // 선택지가 있는 경우 선택지 버튼 생성
            if (sentence.choices != null && sentence.choices.Count > 0)
            {
                CreateChoiceButtons(sentence.choices);
            }
        }
        else
        {
            // 모든 문장을 완료한 경우 다음 씬으로 전환
            if (currentScene.nextScene != null)
            {
                PlayScene(currentScene.nextScene);
            }
            else
            {
                state = State.COMPLETED;
            }
        }
    }

    private void CreateChoiceButtons(List<StoryScene.Choice> choices)
    {
        // 기존의 선택지 버튼 제거
        foreach (Transform child in choicesContainer)
        {
            Destroy(child.gameObject);
        }

        // 선택지 버튼 생성
        foreach (var choice in choices)
        {
            GameObject button = Instantiate(choiceButtonPrefab, choicesContainer);
            button.GetComponentInChildren<TextMeshProUGUI>().text = choice.choiceText;
            button.GetComponent<Button>().onClick.AddListener(() => OnChoiceSelected(choice.nextScene));
        }
    }

    private void OnChoiceSelected(StoryScene nextScene)
    {
        PlayScene(nextScene); // 선택된 씬으로 전환
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
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
}
