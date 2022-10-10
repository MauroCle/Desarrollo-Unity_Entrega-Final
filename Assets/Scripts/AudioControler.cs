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
    //public float pitchReducction;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = GameManager.MusicVolume / 100;
        ShipColisionDetector.Collided += ReducePitch;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(pitchReduced && audioSource.pitch > 0)
            GetComponent<AudioSource>().pitch -= 0.02f;
        else if (!pitchReduced && audioSource.pitch < 1)
            GetComponent<AudioSource>().pitch += 0.03f;
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

    void ReducePitch()
    {
        pitchReduced = true;
    }
    private void OnDisable()
    {
        ShipColisionDetector.Collided -= ReducePitch;
    }

}
