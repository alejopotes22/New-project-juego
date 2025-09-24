using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum ItemType { Apple, Banana }

    public ItemType type = ItemType.Apple;
    public int itemValue = 1;

    [Header("Audio")]
    public AudioClip appleClip;
    public AudioClip bananaClip;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        switch (type)
        {
            case ItemType.Apple:
                GameManager.Instance.TotalApple(itemValue);
                PlaySound(appleClip);
                break;

            case ItemType.Banana:
                GameManager.Instance.TotalBanana(itemValue);
                PlaySound(bananaClip);
                break;
        }

        // destruye el objeto después de que termine el sonido
        Destroy(gameObject, 0.2f);
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {

            audioSource.volume = 1f; // máximo volumen (ajústalo entre 0.0 y 1.0)
            audioSource.priority = 50; // menor número = mayor prioridad

            audioSource.PlayOneShot(clip);
        }
    }
}

