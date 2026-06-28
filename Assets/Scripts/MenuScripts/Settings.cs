using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider master;
    [SerializeField] Slider music;
    [SerializeField] Slider sfx;

    void Start()
    {
        master.value = AudioManager.instance.masterVolume;
        music.value = AudioManager.instance.musicVolume;
        sfx.value = AudioManager.instance.sfxVolume;
    }   

    public void musicValue()
    {
        AudioManager.instance.audioSource.volume = music.value * master.value;
    }
    public void goToLast()
    {
        AudioManager.instance.SaveVolumes(master.value,music.value,sfx.value);
        SceneManager.UnloadSceneAsync(2);
        Time.timeScale = 1f;
    }

    void Update()
    {
        
    }
}