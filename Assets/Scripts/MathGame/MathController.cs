using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro ??쇱뿫??쎈읂??곷뮞 ?곕떽?
using UnityEngine.SceneManagement;
public class MathController : MonoBehaviour
{
    public TextMeshProUGUI problemText; // ?얜챷????용뮞??
    public Button[] answerButtons; // ???툧 甕곌쑵??
    public TextMeshProUGUI scoreText; // ?癒?땾 ??용뮞??
    public TextMeshProUGUI timerText; // ????????용뮞??
    public float timeLimit = 30f; // ?얜챷?????쀫립 ??볦퍢

    private string correctAnswer; // ?類ｋ뼗
    private int score = 0; // ?癒?땾
    private float currentTime; // ?袁⑹삺 ??볦퍢
    private bool isTimeUp = false; // ??볦퍢 ?λ뜃?????

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

        // ??뺣쑁??곗쨮 ?얜챷???醫륁굨 ?醫뤾문
        int problemType = Random.Range(0, 2);

        switch (problemType)
        {
            case 0:
                // ??而?몴???ъ쁽??筌띿쉸????얜챷????밴쉐
                problem = GenerateNumberProblem();
                answers = GenerateNumberAnswers();
                break;
            case 1:
                // ??而?몴?????怨쀪텦??筌띿쉸????얜챷????밴쉐
                problem = GenerateOperationProblem();
                answers = GenerateOperationAnswers();
                break;
            default:
                problem = ""; // ?癒?쑎 獄쎻뫗????袁る립 疫꿸퀡??첎???쇱젟
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
        // ?怨쀪텦?癒? ??뜆萸??곗쨮 ??筌ｋ똾釉???얜챷????밴쉐
        return $"{number1} ? {number2} = {result}";
    }

    List<string> GenerateNumberAnswers()
    {
        List<string> answers = new List<string>();
        answers.Add(correctAnswer);

        while (answers.Count < answerButtons.Length)
        {
            string randomAnswer = Random.Range(1, 20).ToString(); // ??뺣쑁????ъ쁽 ??밴쉐
            if (!answers.Contains(randomAnswer)) // 餓λ쵎??????뱽 獄쎻뫗?
            {
                answers.Add(randomAnswer);
            }
        }

        return answers;
    }

    List<string> GenerateOperationAnswers()
    {
        List<string> answers = new List<string>();

        // 筌뤴뫀諭?????怨쀪텦??甕곌쑵????곕떽?
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