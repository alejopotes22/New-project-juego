using UnityEngine;

public class FinalFlagTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("�Jugador lleg� a la meta!");
            FindObjectOfType<EndPanelController>()?.ShowEndPanel();
        }
    }

}

