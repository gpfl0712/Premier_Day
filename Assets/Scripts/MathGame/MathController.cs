using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro 네임스페이스 추가

public class MathController : MonoBehaviour
{
    public TextMeshProUGUI problemText; // 문제 텍스트
    public Button[] answerButtons; // 답안 버튼
    public TextMeshProUGUI scoreText; // 점수 텍스트
    public TextMeshProUGUI timerText; // 타이머 텍스트
    public float timeLimit = 30f; // 문제당 제한 시간

    private string correctAnswer; // 정답
    private int score = 0; // 점수
    private float currentTime; // 현재 시간
    private bool isTimeUp = false; // 시간 초과 여부

    void Start()
    {
        GenerateNewProblem();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Max(currentTime, 0).ToString("F2");

        if (currentTime <= 0)
        {
            isTimeUp = true;
            GenerateNewProblem();
        }
    }

    void GenerateNewProblem()
    {
        currentTime = timeLimit;
        isTimeUp = false;

        string problem;
        List<string> answers;

        // 랜덤으로 문제 유형 선택
        int problemType = Random.Range(0, 2);

        switch (problemType)
        {
            case 0:
                // 올바른 숫자를 맞추는 문제 생성
                problem = GenerateNumberProblem();
                answers = GenerateNumberAnswers();
                break;
            case 1:
                // 올바른 사칙연산을 맞추는 문제 생성
                problem = GenerateOperationProblem();
                answers = GenerateOperationAnswers();
                break;
            default:
                problem = ""; // 에러 방지를 위한 기본값 설정
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
        if(operation=='/')
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
        correctAnswer=CalculateAnswer2(number1, number2,result).ToString();
        // 연산자를 빈칸으로 대체하여 문제 생성
        return $"{number1} ? {number2} = {result}";
    }

    List<string> GenerateNumberAnswers()
    {
        List<string> answers = new List<string>();
        answers.Add(correctAnswer);

        while (answers.Count < answerButtons.Length)
        {
            string randomAnswer = Random.Range(1, 20).ToString(); // 랜덤한 숫자 생성
            if (!answers.Contains(randomAnswer)) // 중복된 답을 방지
            {
                answers.Add(randomAnswer);
            }
        }

        return answers;
    }

    List<string> GenerateOperationAnswers()
    {
        List<string> answers = new List<string>();

        // 모든 사칙연산을 버튼에 추가
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

char  CalculateAnswer2(int number1, int number2, int number3)
    {   
        if(number1+number2==number3)
        {
            return '+';
        }
        else if(number1-number2==number3)
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
