
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
    public string minigame;
    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Image Character;
        public Speaker speaker;
        public List<Choice> choices;
    }
    [System.Serializable]
  
    public class Choice
    {
        public string text; // ?醫뤾문筌왖 ??용뮞??
        public StoryScene nextScene; // ?醫뤾문 ????猷????쇱벉 ??
    }

}
