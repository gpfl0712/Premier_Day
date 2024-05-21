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

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Sprite characterImage; // 筌?Ŧ??????筌왖 ?곕떽?
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
