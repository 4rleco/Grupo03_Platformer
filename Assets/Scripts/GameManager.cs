using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        player.OnGameOver += OnGameOver;
    }

    private void OnGameOver(bool obj)
    {
       Time.timeScale = 0;
        gameOverPanel.SetActive(obj);
    }
}
