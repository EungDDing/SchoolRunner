using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum BGM_Type
{ 
    BGM_Streamer = 0,
    BGM_Doctor,
    BGM_Singer,
    BGM_FootballPlayer,
    BGM_MusicalActor,
    BGM_Police,
    BGM_Parttime,
    BGM_Lobby,
    BGM_Running
}
public enum SFX_Type
{
    SFX_Coin,
    SFX_Item,
    SFX_Click
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] private AudioMixer audioMaster;

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
    private void Start()
    {
        OnOffBGM(GameManager.instance.Data.bgm);
        OnOffSFX(GameManager.instance.Data.sfx);
    }
    public void ChangeBGM(BGM_Type newBGM)
    {
        StartCoroutine(ChangeBGMClip(bgmList[(int)newBGM]));
    }

    private float current;
    private float percent;

    private IEnumerator ChangeBGMClip(AudioClip newClip)
    {
        current = 0.0f;
        percent = 0.0f;
        // decrease current bgm volume
        while (percent < 1.0f)
        {
            current += Time.deltaTime;
            percent = current / 1.0f;
            bgmPlayer.volume = Mathf.Lerp(1.0f, 0.0f, percent);
            yield return null;
        }

        bgmPlayer.clip = newClip;
        bgmPlayer.Play();
        current = 0.0f;
        percent = 0.0f;
        // increase new bgm volume
        while (percent < 1.0f)
        {
            current += Time.deltaTime;
            percent = current / 1.0f;
            bgmPlayer.volume = Mathf.Lerp(0.0f, 1.0f, percent);
            yield return null;
        }
    }

    private int cursor = 0;
    public void PlaySFX(SFX_Type sfx)
    {
        sfxPlayer[cursor].clip = sfxList[(int)sfx];
        sfxPlayer[cursor].Play();
        cursor++;
        if (cursor > sfxPlayer.Count - 1)
        {
            cursor = 0;
        }
    }
    public void OnOffBGM(bool isOn)
    {
        GameManager.instance.Data.bgm = isOn;
        GameManager.instance.SaveData();

        float volume = isOn ? 0f : -80f;
        audioMaster.SetFloat("BGM", volume);
    }

    public void OnOffSFX(bool isOn)
    {
        GameManager.instance.Data.sfx = isOn;
        GameManager.instance.SaveData();

        float volume = isOn ? 0f : -80f;
        audioMaster.SetFloat("SFX", volume);
    }
}