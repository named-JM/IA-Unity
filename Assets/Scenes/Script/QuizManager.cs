using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuizManager : MonoBehaviour
{
    public QuizData[] quizzes;       // Array of all quizzes
    public Text questionText;        // UI Text for the question
    public Image questionImage;      // UI Image for the question
    public Button[] optionButtons;   // Buttons for the options
    public Text timerText;           // Timer text
    public Text scoreText;           // Score text
    public GameObject resultPanel;   // Result panel
    public Text resultText;          // Result text

    private int currentQuizIndex = 0;
    private int score = 0;
    public float timerDuration = 30f;
    private float timer;
    private bool isQuizActive = false;

    private void Start()
    {
        score = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = " " + score;

        LoadQuiz();
    }

    private void Update()
    {
        if (isQuizActive)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + Mathf.Clamp(timer, 0, 30).ToString("0");

            if (timer <= 0)
            {
                HandleTimeout();
            }
        }
    }

    private void LoadQuiz()
    {
        if (quizzes == null || quizzes.Length == 0)
        {
            Debug.LogError("Quizzes array is empty or null!");
            return;
        }

        if (currentQuizIndex >= quizzes.Length)
        {
            ShowResult();
            return;
        }

        Debug.Log($"Loading Quiz {currentQuizIndex}");

        QuizData quiz = quizzes[currentQuizIndex];

        if (quiz == null)
        {
            Debug.LogError($"Quiz at index {currentQuizIndex} is null!");
            return;
        }

        questionText.text = quiz.question;
        questionImage.sprite = quiz.questionImage;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < quiz.options.Length)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<Text>().text = quiz.options[i];
                int index = i;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => CheckAnswer(index));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }


    private void CheckAnswer(int index)
    {
        isQuizActive = false;

        if (index == quizzes[currentQuizIndex].correctAnswerIndex)
        {
            score += 10;
            scoreText.text = " " + score;

            PlayerPrefs.SetInt("PlayerScore", score);
            PlayerPrefs.Save();
        }

        currentQuizIndex++;
        LoadQuiz();
    }

    private void HandleTimeout()
    {
        isQuizActive = false;
        currentQuizIndex++;
        LoadQuiz();
    }

    private void ShowResult()
    {
        resultPanel.SetActive(true);
        resultText.text = $"Final Score: {score}";

        PlayerPrefs.SetInt("PlayerScore", score);
        PlayerPrefs.Save();
    }
}
