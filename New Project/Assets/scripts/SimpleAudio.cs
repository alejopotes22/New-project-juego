using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SimpleAudio : MonoBehaviour
{

    [Header("Referencias")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Button nextAudio;

    [SerializeField] private List<AudioClip> listClips = new List<AudioClip>();

    [SerializeField] bool loopPlayList = true;

    private int index = -1;

    private void Awake()
    {
        if (nextAudio != null)
        {
           nextAudio.onClick.AddListener(PlayNext);
        }

    }

    private void OnDestroy()
    {
        if (nextAudio != null)
        {
            nextAudio.onClick.RemoveListener(PlayNext);
        }
    }

    public void PlayNext()
    {
        if (listClips.Count == 0 || audioSource == null) return;
        index++;
        if (index >= listClips.Count)
        {
            if (loopPlayList)
            {
                index = 0;
            }
            else
            {
                index = listClips.Count - 1;
                
            }
        }
        audioSource.Stop();
        audioSource.clip = listClips[index];
        audioSource.Play();
    }


}
