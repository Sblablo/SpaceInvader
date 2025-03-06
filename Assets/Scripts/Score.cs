using System;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highestScoreText;
    private void Awake()
    {
        Enemy.OnEnemyDied += addScore;
        Ovni.OnOvniDie += addScore;
        if (!PlayerPrefs.HasKey("highestScore"))
        {
            PlayerPrefs.SetInt("highestScore", 0);
        }
        scoreText.text = $"SCORE\n{score:D4}";
        highestScoreText.text = $"HI-SCORE\n{PlayerPrefs.GetInt("highestScore"):D4}";
    }
    private void OnDestroy()
    {
        Enemy.OnEnemyDied -= addScore;
        Ovni.OnOvniDie -= addScore;
        PlayerPrefs.Save();
    }
    
    public void addScore(int points)
    {
        score += points;
        scoreText.text = $"SCORE\n{score:D4}";
        if (score > PlayerPrefs.GetInt("highestScore"))
        {
            PlayerPrefs.SetInt("highestScore", score);
            highestScoreText.text = $"HI-SCORE\n{PlayerPrefs.GetInt("highestScore"):D4}";
            PlayerPrefs.Save();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
