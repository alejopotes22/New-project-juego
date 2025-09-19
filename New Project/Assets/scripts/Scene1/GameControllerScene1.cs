using UnityEngine;
using TMPro;    

public class GameControllerScene1 : MonoBehaviour
{

    public Timer tiempoEscena;
    public TMPro.TextMeshProUGUI textApple;
    public TMPro.TextMeshProUGUI textBanana;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (GameManager.Instance != null)
        {

            int apples = GameManager.Instance.ScoreApple; 
            int bananas = GameManager.Instance.ScoreBanana;
            textApple.text = apples.ToString(); 
            textBanana.text = bananas.ToString();
        }



    }

    public void AddTime()
    {
        tiempoEscena.TimerStop();
        float getTimeScene = tiempoEscena.StopTime;

        GameManager.Instance.TotalTime(getTimeScene);

        Debug.Log("Tiempo Escena 1 " + GameManager.Instance.GlobalTime);
    }

}
