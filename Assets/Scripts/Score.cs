using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;
    public void UpdateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
