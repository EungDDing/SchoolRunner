using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioSource bgmPlayer;
    [SerializeField] private List<AudioClip> bgmList;

    [SerializeField] private List<AudioSource> sfxPlayer;
    [SerializeField] private List<AudioClip> sfxList;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
