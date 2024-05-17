
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName ="NewStoryScene",menuName ="Data/New Story Scene")]
[System.Serializable]
public class StoryScene : ScriptableObject
{
    public List<Sentence> sentences;
    public Sprite background;
    public StoryScene nextScene;
    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Image Character;
        public Speaker speaker;
        public List<Choice> choices;
    }
    [System.Serializable]
    public struct Choice
    {
        public string choiceText; // 선택지 텍스트
        public StoryScene nextScene; // 선택 시 넘어갈 씬
    }
}
