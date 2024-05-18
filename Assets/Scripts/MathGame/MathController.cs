using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro ?ㅼ엫?ㅽ럹?댁뒪 異붽?
using UnityEngine.SceneManagement;
public class MathController : MonoBehaviour
{
    public TextMeshProUGUI problemText; // 臾몄젣 ?띿뒪??
    public Button[] answerButtons; // ?듭븞 踰꾪듉
    public TextMeshProUGUI scoreText; // ?먯닔 ?띿뒪??
    public TextMeshProUGUI timerText; // ??대㉧ ?띿뒪??
    public float timeLimit = 30f; // 臾몄젣???쒗븳 ?쒓컙

    private string correctAnswer; // ?뺣떟
    private int score = 0; // ?먯닔
    private float currentTime; // ?꾩옱 ?쒓컙
    private bool isTimeUp = false; // ?쒓컙 珥덇낵 ?щ?

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
         
            SceneManager.LoadScene("MainStory2");
        }
    }

    void GenerateNewProblem()
    {
    
       

        string problem;
        List<string> answers;

        // ?쒕뜡?쇰줈 臾몄젣 ?좏삎 ?좏깮
        int problemType = Random.Range(0, 2);

        switch (problemType)
        {
            case 0:
                // ?щ컮瑜??レ옄瑜?留욎텛??臾몄젣 ?앹꽦
                problem = GenerateNumberProblem();
                answers = GenerateNumberAnswers();
                break;
            case 1:
                // ?щ컮瑜??ъ튃?곗궛??留욎텛??臾몄젣 ?앹꽦
                problem = GenerateOperationProblem();
                answers = GenerateOperationAnswers();
                break;
            default:
                problem = ""; // ?먮윭 諛⑹?瑜??꾪븳 湲곕낯媛??ㅼ젙
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
        // ?곗궛?먮? 鍮덉뭏?쇰줈 ?泥댄븯??臾몄젣 ?앹꽦
        return $"{number1} ? {number2} = {result}";
    }

    List<string> GenerateNumberAnswers()
    {
        List<string> answers = new List<string>();
        answers.Add(correctAnswer);

        while (answers.Count < answerButtons.Length)
        {
            string randomAnswer = Random.Range(1, 20).ToString(); // ?쒕뜡???レ옄 ?앹꽦
            if (!answers.Contains(randomAnswer)) // 以묐났???듭쓣 諛⑹?
            {
                answers.Add(randomAnswer);
            }
        }

        return answers;
    }

    List<string> GenerateOperationAnswers()
    {
        List<string> answers = new List<string>();

        // 紐⑤뱺 ?ъ튃?곗궛??踰꾪듉??異붽?
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
