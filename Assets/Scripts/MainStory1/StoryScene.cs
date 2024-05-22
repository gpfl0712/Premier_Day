using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewStoryScene", menuName = "Data/New Story Scene")]
[System.Serializable]
public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite background;
    public StoryScene nextScene;
    public string minigame;
    public bool IsEnding=false;
    public string time;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Sprite characterImage; // 嶺?큔???????嶺뚯솘? ?怨뺣뼺?
        public Speaker speaker;
        public List<Choice> choices;
    }

    [System.Serializable]
    public class Choice
    {
        public string text;
        public bool Good;
        public StoryScene HasItem;
        public StoryScene nextScene;
    }
}
