using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject credits;
    [SerializeField] private GameObject menu;
    private void Start()
    {
        credits.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(0);
    }
    public void Settings()
    {
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }
    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
    }
    public void BackToMenu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
