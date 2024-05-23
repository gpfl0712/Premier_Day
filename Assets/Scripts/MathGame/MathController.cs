using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro ???깅엮???덉쓡??怨룸츩 ?怨뺣뼺?
using UnityEngine.SceneManagement;
public class MathController : MonoBehaviour
{
    public TextMeshProUGUI problemText; // ??쒖굣?????⑸츩??
    public Button[] answerButtons; // ??????뺢퀗???
    public TextMeshProUGUI scoreText; // ????????⑸츩??
    public TextMeshProUGUI timerText; // ??????????⑸츩??
    public float timeLimit = 30f; // ??쒖굣??????ル┰ ??蹂?뜟

    private string correctAnswer; // ?筌먲퐢堉?
    private int score = 0; // ?????
    private float currentTime; // ?熬곣뫗????蹂?뜟
    private bool isTimeUp = false; // ??蹂?뜟 ?貫??????

    void Start()
    {
        GenerateNewProblem();
        currentTime = timeLimit;
        
    }

    void Update()
    {

        currentTime -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Max(currentTime, 0).ToString("F2");

        if (currentTime <= 0)
        {
            PlayerPrefs.SetInt("FinalScore", score);
            SceneManager.LoadScene("MathResult");
        }
    }

    void GenerateNewProblem()
    {



        string problem;
        List<string> answers;

        // ??類ｌ몓??怨쀬Ŧ ??쒖굣????ル쪇援???ルㅎ臾?
        int problemType = Random.Range(0, 2);

        switch (problemType)
        {
            case 0:
                // ????紐???????嶺뚮씮??????쒖굣????諛댁뎽
                problem = GenerateNumberProblem();
                answers = GenerateNumberAnswers();
                break;
            case 1:
                // ????紐??????⑥ろ뀰??嶺뚮씮??????쒖굣????諛댁뎽
                problem = GenerateOperationProblem();
                answers = GenerateOperationAnswers();
                break;
            default:
                problem = ""; // ??????꾩렮維????熬곥굥由??リ옇???泥????깆젧
                answers = new List<string>();
                break;
        }

        problemText.text = problem;

        answers.Shuffle();

        for (int i = 0; i < answerButtons.Length; i++)
        {
            string answer = answers[i];
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answer;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() => CheckAnswer(answer));
        }
    }

    void CheckAnswer(string selectedAnswer)
    {
        Debug.Log("Selected Answer: " + selectedAnswer);
        Debug.Log("Correct Answer: " + correctAnswer);

        if (!isTimeUp && selectedAnswer == correctAnswer)
        {
            score++;
            Debug.Log("Correct! Score: " + score);
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.Log("Wrong answer! Correct answer was: " + correctAnswer);
        }

        GenerateNewProblem();
    }

    string GenerateNumberProblem()
    {
        char operation = GetRandomOperation();
        int number1 = Random.Range(1, 30);
        int number2 = Random.Range(1, 9);
        if (operation == '/')
        {
            while (number1 % number2 != 0)
            {
                number1 = Random.Range(1, 30);
                number2 = Random.Range(1, 9);
            }
        }
        int result;

        result = CalculateAnswer(number1, number2, operation);
        correctAnswer = CalculateAnswer1(number1, number2, result).ToString();
        return $"{number1} {operation} ? = {result}";
    }

    string GenerateOperationProblem()
    {
        int result;
        int number1 = Random.Range(1, 30);
        int number2 = Random.Range(1, 9);
        char operation = GetRandomOperation();
        if (operation == '/')
        {
            while (number1 % number2 != 0)
            {
                number1 = Random.Range(1, 30);
                number2 = Random.Range(1, 9);
            }
        }
        result = CalculateAnswer(number1, number2, operation);
        correctAnswer = CalculateAnswer2(number1, number2, result).ToString();
        // ??⑥ろ뀰??? ???녻맱??怨쀬Ŧ ??嶺뚳퐢?얗뇡????쒖굣????諛댁뎽
        return $"{number1} ? {number2} = {result}";
    }

    List<string> GenerateNumberAnswers()
    {
        List<string> answers = new List<string>();
        answers.Add(correctAnswer);

        while (answers.Count < answerButtons.Length)
        {
            string randomAnswer = Random.Range(1, 20).ToString(); // ??類ｌ몓?????????諛댁뎽
            if (!answers.Contains(randomAnswer)) // 繞벿살탮??????諭??꾩렮維?
            {
                answers.Add(randomAnswer);
            }
        }

        return answers;
    }

    List<string> GenerateOperationAnswers()
    {
        List<string> answers = new List<string>();

        // 嶺뚮ㅄ維獄??????⑥ろ뀰???뺢퀗?????怨뺣뼺?
        answers.Add("+");
        answers.Add("-");
        answers.Add("*");
        answers.Add("/");

        return answers;
    }

    char GetRandomOperation()
    {
        char[] operations = { '+', '-', '*', '/' };
        return operations[Random.Range(0, operations.Length)];
    }

    int CalculateAnswer(int number1, int number2, char operation)
    {
        switch (operation)
        {
            case '+':
                return number1 + number2;
            case '-':
                return number1 - number2;
            case '*':
                return number1 * number2;
            case '/':
                return number1 / number2;
            default:
                return 0;
        }
    }
    int CalculateAnswer1(int number1, int number2, int number3)
    {
        if (number1 + number2 == number3)
        {
            return number2;
        }
        else if (number1 - number2 == number3)
        {
            return number2;

        }
        else if (number1 * number2 == number3)
        {
            return number2;

        }
        else
        {
            return number2;
        }
    }

    char CalculateAnswer2(int number1, int number2, int number3)
    {
        if (number1 + number2 == number3)
        {
            return '+';
        }
        else if (number1 - number2 == number3)
        {
            return '-';

        }
        else if (number1 * number2 == number3)
        {
            return '*';

        }
        else
        {
            return '/';
        }
    }
}

public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}