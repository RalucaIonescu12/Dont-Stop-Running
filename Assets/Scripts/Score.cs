using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text ScoreText;
    private static float score;
    private bool scoreCounting = false;

    public Text highScore;

    void Start()
    {
        score = 0;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scoreCounting = true;
        }

        if (scoreCounting)
        {
            score += 1 * Time.deltaTime;
            ScoreText.text = ((int)score).ToString();

            PlayerPrefs.SetInt("Score", (int)score);


            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", (int)score);
                highScore.text = score.ToString("0");
            }
        }
    }

    public static float GetCurrentScore()
    {
        return score;
    }




}
