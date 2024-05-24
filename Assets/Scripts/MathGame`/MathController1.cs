using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro 사용을 위해 추가
using UnityEngine.SceneManagement;

public class MathController1 : MonoBehaviour
{
    public TextMeshProUGUI problemText; // 문제 텍스트를 표시하는 TextMeshProUGUI
    public Button[] answerButtons; // 답변 버튼 배열
    public TextMeshProUGUI scoreText; // 점수 텍스트를 표시하는 TextMeshProUGUI
    public TextMeshProUGUI timerText; // 타이머 텍스트를 표시하는 TextMeshProUGUI
    public float timeLimit = 30f; // 제한 시간 설정

    private string correctAnswer; // 정답 문자열
    private int score = 0; // 점수 초기화
    private float currentTime; // 현재 시간
    private bool isTimeUp = false; // 시간이 다 되었는지 여부

    void Start()
    {
        GenerateNewProblem(); // 새로운 문제 생성
        currentTime = timeLimit; // 제한 시간 초기화
    }

    void Update()
    {
        currentTime -= Time.deltaTime; // 시간 경과에 따라 currentTime 감소
        timerText.text = "Time: " + Mathf.Max(currentTime, 0).ToString("F2"); // 남은 시간 표시

        if (currentTime <= 0) // 시간이 다 되었을 때
        {
            PlayerPrefs.SetInt("FinalScore", score); // 최종 점수 저장
            SceneManager.LoadScene("MathResult2"); // 결과 화면으로 전환
        }
    }

    void GenerateNewProblem()
    {
        string problem;
        List<string> answers;

        // 문제 유형을 무작위로 선택 (0 또는 1)
        int problemType = Random.Range(0, 2);

        switch (problemType)
        {
            case 0:
                problem = GenerateNumberProblem(); // 숫자 문제 생성
                answers = GenerateNumberAnswers(); // 숫자 문제 답변 생성
                break;
            case 1:
                problem = GenerateOperationProblem(); // 연산 문제 생성
                answers = GenerateOperationAnswers(); // 연산 문제 답변 생성
                break;
            default:
                problem = ""; // 기본값 설정
                answers = new List<string>();
                break;
        }

        problemText.text = problem; // 문제 텍스트 설정
        answers.Shuffle1(); // 답변 무작위로 섞기

        // 각 버튼에 답변 텍스트와 클릭 이벤트 추가
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

        if (!isTimeUp && selectedAnswer == correctAnswer) // 정답 확인
        {
            score++; // 점수 증가
            Debug.Log("Correct! Score: " + score);
            scoreText.text = "Score: " + score; // 점수 텍스트 업데이트
        }
        else
        {
            Debug.Log("Wrong answer! Correct answer was: " + correctAnswer); // 오답 처리
        }

        GenerateNewProblem(); // 새로운 문제 생성
    }

    string GenerateNumberProblem()
    {
        char operation = GetRandomOperation(); // 무작위 연산자 선택
        int number1 = Random.Range(1, 30);
        int number2 = Random.Range(1, 9);
        if (operation == '/')
        {
            while (number1 % number2 != 0) // 나누어 떨어지지 않을 경우 재선택
            {
                number1 = Random.Range(1, 30);
                number2 = Random.Range(1, 9);
            }
        }
        int result = CalculateAnswer(number1, number2, operation); // 정답 계산
        correctAnswer = CalculateAnswer1(number1, number2, result).ToString(); // 정답 설정
        return $"{number1} {operation} ? = {result}"; // 문제 문자열 생성
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
        return $"{number1} ? {number2} = {result}"; // 연산 문제 문자열 생성
    }

    List<string> GenerateNumberAnswers()
    {
        List<string> answers = new List<string>();
        answers.Add(correctAnswer);

        while (answers.Count < answerButtons.Length) // 중복되지 않는 답변 생성
        {
            string randomAnswer = Random.Range(1, 20).ToString();
            if (!answers.Contains(randomAnswer))
            {
                answers.Add(randomAnswer);
            }
        }

        return answers;
    }

    List<string> GenerateOperationAnswers()
    {
        List<string> answers = new List<string>();

        // 가능한 연산자 추가
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

// 리스트 확장 메서드 정의
public static class ListExtension
{
    public static void Shuffle1<T>(this IList<T> list)
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
