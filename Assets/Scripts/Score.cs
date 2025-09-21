using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    private int score = 0;
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
        finalScoreText.text = "You earned " + score + " point(s)!";
    }
}
