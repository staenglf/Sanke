using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Snake sn;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    private int score;
    private int highscore;

    // Start is called before the first frame update
    private void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        highscoreText.text = highscore.ToString();
    }

    // Deletes the attached rectangles, sets the snake to the start point and the score to 0
    public void RestartGame()
    {
        for(int i = 1; i < sn.segments.Count; i++)
        {
            Destroy(sn.segments[i]);
        }

        sn.segments.RemoveRange(1, sn.segments.Count - 1);

        sn.transform.position = Vector2.zero;

        score = 0;
        scoreText.text = score.ToString();

        SaveHighscore();
    }

    // Adds 1 to the score by every food collission an overwrites the highscore
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score > highscore)
        {
            highscore = score;
            highscoreText.text = highscore.ToString();
        }
    }

    // Saves the highscore in the PlayerPrefs when the game gets closed
    private void SaveHighscore()
    {
        if(highscore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
}
