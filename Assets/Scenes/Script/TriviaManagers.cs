using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriviaManagers : MonoBehaviour
{
    public static string selectedTrivia = "";  // Store selected trivia text
    public void LoadTrivia(string triviaText)
    {
        selectedTrivia = triviaText;
        SceneManager.LoadScene("TriviaScene1");
    }
}
