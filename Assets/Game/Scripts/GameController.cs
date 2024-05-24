using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private bool isGameRunning;
    private int score;
    private int currentLevelIndex;


    public ObstacleGenerator obstacleGenerator;
    public GameConfiguration config;
    public TextMeshProUGUI scoreLabel;
    public GameUI gameStartUI;
    public GameUI gameOverUI;
    public Player player;
    public LevelConfiguration[] levels;

    void Start()
    {
        isGameRunning = false;
        gameStartUI.Show();

        config.speed = 0f;
    }

    void Update()
    {
        scoreLabel.text = score.ToString("000000000.##");

        if (!isGameRunning) return;
        score++;
        CheckLevelUpdate();
    }

    public void GameStart()
    {
        currentLevelIndex = 0;
        SetCurrentLevelConfiguration();
        isGameRunning=true;
        obstacleGenerator.GenerateObstacles();
        score = 0;
        gameStartUI.Hide();
        player.SetActive();
    }

    public void GameOver() 
    {
        print("Jogo acabou!");

        isGameRunning = false;
        config.speed = 0f;
        obstacleGenerator.StopGenerator();

        gameOverUI.Show();
    }

    public void RestartGame()
    {
        gameOverUI.Hide();
        obstacleGenerator.ResetGenerator();
        GameStart();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    private void CheckLevelUpdate()
    {
        if (currentLevelIndex >= levels.Length - 1) return;
        if (score < levels[currentLevelIndex + 1].minScore) return;

        currentLevelIndex++;

        SetCurrentLevelConfiguration();
    }

    private void SetCurrentLevelConfiguration()
    {
        
        LevelConfiguration level = levels[currentLevelIndex];
        config.speed = level.speed;
        config.minRangeObstacleGenerator = level.minRangeObstacleGenerator;
        config.maxRangeObstacleGenerator= level.maxRangeObstacleGenerator;
    }
}
