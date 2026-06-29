using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] public TMP_Text Lives;
    [SerializeField] public GameObject pauseMenu;
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
        if (Time.timeScale == 1)
        {
            pauseMenu.SetActive(false);
        }
        else
        {
            pauseMenu.SetActive(true);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
    }
    public void Settings()
    {
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
    }
    public void Menu()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
