using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    public Text scoreText;

    private void Start()
    {
        // Retrieve the score from PlayerPrefs
        int score = PlayerPrefs.GetInt("PlayerScore", 0);
        scoreText.text = " " + score.ToString();
    }
}
