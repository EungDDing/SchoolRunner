using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningSceneManager : MonoBehaviour
{
    private PlayerController playerController;
    private ScoreManager scoreManager;
    private ScrollManager scrollManager;
    private StageManager stageManager;
    private void Start()
    {
        LoadSceneInit();
    }
    public void LoadSceneInit()
    {
        SoundManager.instance.ChangeBGM(BGM_Type.BGM_Lobby);
        playerController = FindAnyObjectByType<PlayerController>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        scrollManager = FindAnyObjectByType<ScrollManager>();
        stageManager = FindAnyObjectByType<StageManager>();
        GameManager.instance.TryGetPlayerData();
        Time.timeScale = 1.0f;
    }
    public void StartGame()
    {
        StartCoroutine(GameStart());
    }
    IEnumerator GameStart()
    {
        SoundManager.instance.ChangeBGM(BGM_Type.BGM_Running);
        playerController.InitPlayer();
        stageManager.InitStageManager();
        yield return new WaitForSeconds(3.0f);
        scrollManager.InitScrollManager(30.0f);
        scoreManager.InitData();
    }
    public void StopGame()
    {
        scrollManager.StopScroll();
    }
    public void ResumeGame()
    {
        scrollManager.StartScroll();
    }
}

