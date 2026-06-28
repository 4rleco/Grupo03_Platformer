using UnityEngine;

public enum SoundType
{
    Collision,
    Perfect
}

public enum MusicType
{
    Music
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] SoundList;
    [SerializeField] private AudioClip GameMusic;
    public static AudioManager instance;
    public AudioSource audioSource;

    private const string MASTER_VOL_KEY = "MasterVolume";
    private const string MUSIC_VOL_KEY = "MusicVolume";
    private const string SFX_VOL_KEY = "SFXVolume";


    public float masterVolume { get; private set; }
    public float musicVolume { get; private set; }
    public float sfxVolume { get; private set; }

    protected void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.generator = GameMusic;
        PlayMusic();
        LoadData();
    }
    private void LoadData()
    {
        masterVolume = PlayerPrefs.GetFloat(MASTER_VOL_KEY, 1.0f);
        musicVolume = PlayerPrefs.GetFloat(MUSIC_VOL_KEY, 1.0f);
        sfxVolume = PlayerPrefs.GetFloat(SFX_VOL_KEY, 1.0f);
    }

    public void SaveVolumes(float master, float music, float sfx)
    {
        masterVolume = master;
        musicVolume = music;
        sfxVolume = sfx;

        PlayerPrefs.SetFloat(MASTER_VOL_KEY, masterVolume);
        PlayerPrefs.SetFloat(MUSIC_VOL_KEY, musicVolume);
        PlayerPrefs.SetFloat(SFX_VOL_KEY, sfxVolume);
        PlayerPrefs.Save();
    }

    public static void PlaySound(SoundType type, float volume = 1)
    {
        instance.audioSource.PlayOneShot(instance.SoundList[(int)type], volume);
    }

    public static void PlayMusic()
    {
        instance.audioSource.Play();
        instance.audioSource.loop = true;
    }
}
