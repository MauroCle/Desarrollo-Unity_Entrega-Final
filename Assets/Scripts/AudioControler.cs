using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{
    public Slider PauseVolumeSlide;
    public Slider LoseVolumeSlide;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = GameManager.MusicVolume / 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPauseVolumeChange()
    {
        GameManager.MusicVolume = PauseVolumeSlide.value;
        GetComponent<AudioSource>().volume = GameManager.MusicVolume / 100;
        UpdatLoseSlider();
    }

    public void OnLoseVolumeChange()
    {
        GameManager.MusicVolume = LoseVolumeSlide.value;
        GetComponent<AudioSource>().volume = GameManager.MusicVolume / 100;
        UpdatePauseSlider();
    }

    void UpdatePauseSlider()
    {
        PauseVolumeSlide.value = GameManager.MusicVolume;
    }

    void UpdatLoseSlider()
    {
        LoseVolumeSlide.value = GameManager.MusicVolume;
    }

}
