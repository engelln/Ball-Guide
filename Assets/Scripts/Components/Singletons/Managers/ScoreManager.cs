using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    private int score;
    private int highScore;

    private void Start()
    {
        score = 0;
        highScore = GetHighScore();
    }

    public void IncrementScore()
    {
        score++;
        if (score > highScore)
        {
            highScore = score;
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public int Score
    {
        get
        {
            return score;
        }
    }

    private int GetHighScore()
    {
        switch (GameManager.Inst.CurrentMode)
        {
            case GameMode.Normal:
                return PlayerPrefs.GetInt("Normal", 0);
            case GameMode.Squeeze:
                return PlayerPrefs.GetInt("Squeeze", 0);
            default:
                return 0;
        }
    }

    private void SetHighScore(int score)
    {
        switch (GameManager.Inst.CurrentMode)
        {
            case GameMode.Normal:
                PlayerPrefs.SetInt("Normal", highScore); break;
            case GameMode.Squeeze:
                PlayerPrefs.SetInt("Squeeze", highScore); break;
        }
    }

    private void OnDestroy()
    {
        SetHighScore(highScore);
    }

    public int HighScore { get { return highScore; } }
}
