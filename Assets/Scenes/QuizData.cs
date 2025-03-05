using UnityEngine;

[CreateAssetMenu(fileName = "NewQuiz", menuName = "Quiz/Create New Quiz")]
public class QuizData : ScriptableObject
{
    public string question;            // The question text
    public Sprite questionImage;       // Associated image for the question
    public string[] options;           // Multiple-choice options
    public int correctAnswerIndex;     // Index of the correct answer (0-based)
}
