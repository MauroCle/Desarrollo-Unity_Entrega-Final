using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public static Action onGameOver;

    public List<GameObject> tiles = new List<GameObject>();
    public PostProcessVolume globalVolume;
    public float DistorionAdjustment = -20;

    static public List<GameObject> staticTiles = new List<GameObject>();
    //static public List<int> NextSection = new List<int>();
    static float speed = 0.5f;
    static float maxSpeed = 3.5f;
    public static float Speed { get => speed; set => speed = value; }
    public static float MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
    public static bool Pause { get => pause; set => pause = value; }

    private static bool pause = false;

    public int points;

    private static bool gameEnded = false;

    public static bool GameEnded { get => gameEnded; set => gameEnded = value; }
    public static float MusicVolume { get => musicVolume; set => musicVolume = value; }

    private static float musicVolume = 50;


    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
            Destroy(gameObject);

        ShipColisionDetector.Collided += GameOver;
        SectionManager.Delete += SpeedUp;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    void Start()
    {

        foreach (var item in tiles)
        {
            staticTiles.Add(item);
        }

    }

    void SpeedUp()
    {
        if (speed < MaxSpeed)
        {
            Speed += 0.03f;

            UpdateDistortion();
        }

    }

    public void UpdatePoints()
    {
        points = PointsManager.lastUpdate;
    }

    void GameOver()
    {
        gameEnded = true;
        onGameOver?.Invoke();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        speed = .5f;
    }

    void UpdateDistortion()
    {
        LensDistortion lensDistortionFX;
        if(globalVolume.profile.TryGetSettings(out lensDistortionFX))
        {
            lensDistortionFX.intensity.value = Speed * DistorionAdjustment;
        }
    }

    private void OnDisable()
    {
        ShipColisionDetector.Collided -= GameOver;
        SectionManager.Delete -= SpeedUp;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
