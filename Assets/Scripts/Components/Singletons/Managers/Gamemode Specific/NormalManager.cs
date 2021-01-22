﻿using UnityEngine;

public class NormalManager : ModeManager
{
    [SerializeField] private Ball ball;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject gameOverMenu;


    private void Start()
    {
        GameManager.Inst.CurrentMode = GameMode.Normal;
        LoadNextLevel();
    }

    // loads a new random level
    private void LoadNextLevel()
    {
        Time.timeScale = 1;
        currentLevelWon = false;
        LineManager.Inst.ClearLines();
        MaterialManager.Inst.ResetMaterials();
        LineManager.Inst.EnableCorrectTool();
        ChuteSpawner.Inst.SpawnChutes();
        ball.SetUpBall();
    }

    // starts the level when the play button is pressed
    public override void StartLevel()
    {
        ball.Activate();
        foreach(GameObject guide in GameObject.FindGameObjectsWithTag("Guide"))
        {
            guide.SetActive(false);
        }
    }

    // marks the current level as won
    public override void WinCurrentLevel()
    {
        currentLevelWon = true;
    }

    // ends the current level and starts a new one
    // materials and score depends on whether the user won the previous level
    public override void EndLevel()
    {
        if (currentLevelWon)
        {
            // user wins level
            ScoreManager.Inst.IncrementScore();
            LoadNextLevel();
        }
        else
        {
            // user loses level
            EnableGameOverMenu();
        }
    }

    private void EnableGameOverMenu()
    {
        Time.timeScale = 0;
        LineManager.Inst.DisableTools();
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public override void RestartGame()
    {
        ScoreManager.Inst.ResetScore();
        gameOverMenu.SetActive(false);
        gameMenu.SetActive(true);
        continued = false;
        LineManager.Inst.EnableCorrectTool();
        LoadNextLevel();
    }

    public override void ContinueGame()
    {
        if (!continued)
        {
            continued = true;
            gameOverMenu.SetActive(false);
            gameMenu.SetActive(true);
            LineManager.Inst.EnableCorrectTool();
            LoadNextLevel();
        }

    }

    // pauses the game
    public override void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            Time.timeScale = 0;
            gameMenu.SetActive(false);
            pauseMenu.SetActive(true);
        }
    }

    // unpauses the game
    public override void UnPauseGame()
    {
        if (paused)
        {
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            gameMenu.SetActive(true);
            LineManager.Inst.EnableCorrectTool();
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

}