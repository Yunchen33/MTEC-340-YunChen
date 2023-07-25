using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI highestScoreText;

    int score = 0;
    int highscore = 0;

    public int Score => score;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "SCORE: " + score.ToString();
        highestScoreText.text = "HIGH Score: " + highscore.ToString();
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score += 1;
        scoreText.text = "SCORE: " + score.ToString();
        if (highscore < score)
        PlayerPrefs.SetInt("highscore", score);
    }
}
