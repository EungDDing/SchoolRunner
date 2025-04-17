using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerController playerController;
    private ScoreManager scoreManager;
    private ScrollManager scrollManager;
    private StageManager stageManager;

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
        LoadSceneInit();
    }
    public void LoadSceneInit()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
        scrollManager = FindAnyObjectByType<ScrollManager>();
        stageManager = FindAnyObjectByType<StageManager>();
    }
    public void StartGame()
    {
        StartCoroutine(GameStart());
    }
    IEnumerator GameStart()
    {
        playerController.InitPlayer();
        stageManager.InitStage();
        scrollManager.InitScrollManager(15.0f);
        yield return new WaitForSeconds(2.0f);
        scoreManager.InitData();
        
    }

}
