using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Slider soundSlider;
    [SerializeField]
    private Slider musicSlider;

    private void OnEnable()
    {
        soundSlider.value = SoundManager.Instance.SoundsVolume * 10;
        musicSlider.value = SoundManager.Instance.MusicVolume * 10;
    }

    public void OnMusicSliderChange(Single volume)
    {
        SoundManager.Instance.SetMusicVolume(volume / 10);
    }

    public void OnSoundSliderChange(Single volume)
    {
        SoundManager.Instance.SetSoundsVolume(volume / 10);
    }

}
