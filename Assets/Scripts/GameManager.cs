using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winGamePanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        winGamePanel.SetActive(false);

        player.OnGameOver += OnGameOver;
        player.OnWinGame += OnWinGame;
    }

    private void OnWinGame(bool obj)
    {
        Time.timeScale = 0;
        winGamePanel.SetActive(obj);
    }

    private void OnGameOver(bool obj)
    {
       Time.timeScale = 0;
        gameOverPanel.SetActive(obj);
    }
}
