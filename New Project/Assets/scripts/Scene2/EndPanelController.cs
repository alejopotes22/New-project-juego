using UnityEngine;
using TMPro;

public class EndPanelController : MonoBehaviour
{
    public GameObject endPanel;
    public TMP_Text endAppleText;
    public TMP_Text endBananaText;
    public TMP_Text endTimeText;

    private void Start()
    {
        if (endPanel != null)
            endPanel.SetActive(false); // lo ocultamos al inicio
    }

    private void OnEnable()
    {
        // Nos suscribimos al evento del GameManager (si quieres hacerlo más pro)
        // pero también podemos simplemente exponer un método público.
    }


    public void SaveJSON()
    {
        string savePath;
        bool saved = GameManager.Instance.SaveGame(out savePath);

        if (saved)
            Debug.Log("✅ Datos guardados correctamente en: " + savePath);
        else
            Debug.LogError("❌ Error al guardar datos");
    }



    public void ShowEndPanel()
    {
        if (endPanel != null)
        {
            endPanel.SetActive(true);

            GameManager.Instance.StopGameTime();

            if (endAppleText != null)
                endAppleText.text = "Manzanas: " + GameManager.Instance.ScoreApple;

            if (endBananaText != null)
                endBananaText.text = "Bananas: " + GameManager.Instance.ScoreBanana;

            if (endTimeText != null)
                endTimeText.text = "Tiempo: " + GameManager.Instance.GlobalTime.ToString("F2") + "s";

            Time.timeScale = 0f; // ⏸ Pausa el juego
        }
    }
}

