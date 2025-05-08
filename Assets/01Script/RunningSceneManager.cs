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
        playerController = FindAnyObjectByType<PlayerController>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        scrollManager = FindAnyObjectByType<ScrollManager>();
        stageManager = FindAnyObjectByType<StageManager>();
        GameManager.instance.TryGetPlayerData();
    }
    public void StartGame()
    {
        StartCoroutine(GameStart());
    }
    IEnumerator GameStart()
    {
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

