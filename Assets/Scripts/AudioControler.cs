using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{
    public Slider PauseVolumeSlide;
    public Slider LoseVolumeSlide;
    public static bool pitchReduced = false;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = GameManager.MusicVolume / 100;
        ShipColisionDetector.Collided += ReducePitch;
        UpdatePauseSlider();
        UpdateLoseSlider();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (pitchReduced && audioSource.pitch > 0)
            audioSource.pitch -= 0.02f;
        else if (!pitchReduced && audioSource.pitch < 1)
            audioSource.pitch += 0.03f;
    }

    public void OnPauseVolumeChange()
    {
        GameManager.MusicVolume = PauseVolumeSlide.value;
        audioSource.volume = GameManager.MusicVolume / 100;
        UpdateLoseSlider();
    }

    public void OnLoseVolumeChange()
    {
        GameManager.MusicVolume = LoseVolumeSlide.value;
        audioSource.volume = GameManager.MusicVolume / 100;
        UpdatePauseSlider();
    }

    void UpdatePauseSlider()
    {
        PauseVolumeSlide.value = GameManager.MusicVolume;
    }

    void UpdateLoseSlider()
    {
        LoseVolumeSlide.value = GameManager.MusicVolume;
    }

    void ReducePitch()
    {
        pitchReduced = true;
    }
    private void OnDisable()
    {
        ShipColisionDetector.Collided -= ReducePitch;
    }

}
