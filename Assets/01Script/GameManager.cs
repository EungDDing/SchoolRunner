using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }
    private PlayerController playerController;
    private ScoreManager scoreManager;

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

        LoadSceneInit();
        StartCoroutine(GameStart());
    }
    private void LoadSceneInit()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    IEnumerator GameStart()
    {
        yield return null;
        playerController.InitPlayer();
        scoreManager.InitData();
    }

}
