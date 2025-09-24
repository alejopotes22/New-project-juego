using TMPro;
using UnityEngine;
using System.IO;


public class GameManager : MonoBehaviour
{

    public static GameManager Instance;

    private float globalTime;
    private bool gameEnded = false;

    private int scoreApple = 0;
    private int scoreBanana = 0;

    


    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // solo acumula tiempo mientras el juego no haya terminado
        if (!gameEnded)
        {
            globalTime += Time.deltaTime;
        }
    }


    public void StopGameTime()
    {
        gameEnded = true; // <- congela el tiempo
    }



    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void TotalApple(int Apple)
    {
        scoreApple += Apple;
    }

    public void TotalBanana(int Banana)
    {
        scoreBanana += Banana;
    }





    [System.Serializable]
    public class GameData
    {
        public int apples;
        public int bananas;
        public float totalTime;
    }

    public bool SaveGame(out string path)
    {
        path = Application.persistentDataPath + "/save.json";

        try
        {
            GameData data = new GameData
            {
                apples = ScoreApple,
                bananas = ScoreBanana,
                totalTime = GlobalTime
            };

            string json = JsonUtility.ToJson(data, true);
            File.WriteAllText(path, json);

            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error al guardar JSON: " + e.Message);
            return false;
        }
    }



    public float GlobalTime { get => globalTime; set => globalTime = value; }
    public int ScoreApple { get => scoreApple; set => scoreApple = value; }
    public int ScoreBanana { get => scoreBanana; set => scoreBanana = value; }
}