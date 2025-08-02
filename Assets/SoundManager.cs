using UnityEngine;

public class SoundManager : MonoBehaviourSingleton<SoundManager>
{
    [SerializeField]
    private AudioSource buttonSound;
    [SerializeField]
    private AudioSource gameSoundSource;
    [SerializeField]
    private AudioSource musicSource;

    private float soundsVolume = 1f;
    private float musicVolume = 1f;

    public float SoundsVolume => soundsVolume;
    public float MusicVolume => musicVolume;

    private void Awake()
    {
        base.Awake();
        LoadSettings();
        musicSource.Play();
    }

    public void SetSoundsVolume(float volume)
    {
        soundsVolume = Mathf.Clamp(volume, 0f, 1f);
        buttonSound.volume = soundsVolume;
        gameSoundSource.volume = soundsVolume;
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp(volume, 0f, 1f);
        musicSource.volume = musicVolume;
    }

    public void PlaySound(AudioClip clip)
    {
        gameSoundSource.PlayOneShot(clip);
    }

    private void LoadSettings()
    {

    }

    private void SaveSettings()
    {

    }
}
