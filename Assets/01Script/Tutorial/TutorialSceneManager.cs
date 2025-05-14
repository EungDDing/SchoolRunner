using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class TutorialSceneManager : MonoBehaviour
{
    private PlayerController playerController;
    private ScrollManager scrollManager;

    private DialogReader dialogReader;
    private List<DialogLine> dialogLines;
    private int currentIndex;

    private void Awake()
    {
        TryGetComponent<DialogReader>(out dialogReader);
        currentIndex = 0;
    }
    private void Start()
    {
        LoadSceneInit();

        dialogLines = dialogReader.LoadDialog();

        ShowDialog(currentIndex);

        StartGame();
    }
    private void OnEnable()
    {
        Stage.OnChangeStageCount += Stop;
    }
    private void ShowDialog(int index)
    {
        DialogLine line = dialogLines[index];
        Debug.Log(line.Script);
    }
    public void LoadSceneInit()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        scrollManager = FindAnyObjectByType<ScrollManager>();
        GameManager.instance.TryGetPlayerData();
    }
    public void StartGame()
    {
        StartCoroutine(GameStart());
    }
    IEnumerator GameStart()
    {
        playerController.InitPlayer();
        yield return new WaitForSeconds(3.0f);
        scrollManager.InitScrollManager(30.0f);
    }
    public void StopGame()
    {
        scrollManager.StopScroll();
    }
    public void ResumeGame()
    {
        scrollManager.StartScroll();
    }
    public void Stop()
    {

    }
   
}

