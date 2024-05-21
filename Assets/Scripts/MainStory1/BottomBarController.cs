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
    public GameObject choiceButtonPrefab;
    public Transform choicesContainer;
    public BackgroundController backgroundController;
    public Image characterImageUI; // 筌?Ŧ??????筌왖????뽯뻻??UI Image

    private int sentenceIndex = -1;
    public StoryScene currentScene;
    private State state = State.COMPLETED;
    public bool isChoiceDisplayed = false;
    private string currentStory;
    private int like = 20;
    private bool mychou;
    private enum State
    {
        PLAYING, COMPLETED
    }
    void Start()
    {
        // ??λ맂 ?꾩옱 ?ㅽ넗由??뺣낫瑜?媛?몄샂
        currentStory = PlayerPrefs.GetString("CurrentStory");
        mychou= (PlayerPrefs.GetInt("mychou", 0) == 1);
        if(mychou==true)
        {
            like += 20;
        }
        Debug.Log("Current Story: " + currentStory);
    }
    private void Update()
    {
        PlayerPrefs.SetInt("like",like);
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
            Debug.Log("like" + like);
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

                // 筌?Ŧ??????筌왖????쇱젟
                if (characterImageUI != null)
                {
                    characterImageUI.sprite = sentence.characterImage;
                    characterImageUI.enabled = sentence.characterImage != null;
                }
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
        isChoiceDisplayed = false;
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
            choiceButton.onClick.AddListener(() => OnChoiceSelected(choice1));
        }
        isChoiceDisplayed = true;
    }

    public void OnChoiceSelected(Choice choice)
    {
        bool keyring = (PlayerPrefs.GetInt("keyring", 0) == 1);
        bool soccershoes = (PlayerPrefs.GetInt("soccershoes", 0) == 1);
        bool brickbear = (PlayerPrefs.GetInt("brickbear", 0) == 1);
        if(choice.Good==true)
        {
            like += 5;
        }
        else
        {
            like -= 2;
        }
        if (choice.nextScene != null)
        {   
            
            if (currentStory == "Han")
            {
                
            }
            if (currentStory == "Choi")
            {
                if (brickbear == true)
                {
                    Debug.Log("brickbear"+brickbear);
                    PlayScene(choice.HasItem);
                    backgroundController.SwitchImage(choice.HasItem.background);
                }
                else
                {
                    Debug.Log("brickbear:" + brickbear);
                    PlayScene(choice.nextScene);
                    backgroundController.SwitchImage(choice.nextScene.background);
                }
            }
            if (currentStory == "Kang")
            {
                if(soccershoes==true)
                {
                    PlayScene(choice.HasItem);
                    backgroundController.SwitchImage(choice.HasItem.background);
                }
                else
                {
                    PlayScene(choice.nextScene);
                    backgroundController.SwitchImage(choice.nextScene.background);
                }
            }
            if (currentStory == "Oh")
            {
                if (keyring == true)
                {
                    PlayScene(choice.HasItem);
                    backgroundController.SwitchImage(choice.HasItem.background);
                }
                else
                {
                    PlayScene(choice.nextScene);
                    backgroundController.SwitchImage(choice.nextScene.background);
                }
            }
        
           
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
