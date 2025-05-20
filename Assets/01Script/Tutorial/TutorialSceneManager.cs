using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialSceneManager : MonoBehaviour
{
    private PlayerController playerController;
    private ScrollManager scrollManager;

    private DialogReader dialogReader;
    private List<DialogLine> dialogLines;
    private int currentIndex;
    private bool isStop;
    private int infoImageIndex;
    private bool openInfo;
    private void Awake()
    {
        TryGetComponent<DialogReader>(out dialogReader);
        currentIndex = 0;
        isStop = false;
        infoImageIndex = -1;
        openInfo = false;
    }
    private void Start()
    {
        LoadSceneInit();

        dialogLines = dialogReader.LoadDialog();

        StartGame();
    }
    private void OnEnable()
    {
        StopPosition.OnEnterStopPosition += Stop;
    }
    private void OnDisable()
    {
        StopPosition.OnEnterStopPosition -= Stop;
    }
    private void Update()
    {
        if ((Input.GetMouseButtonDown(0) || IsTouchBegan()) && isStop)
        {
            NextDialog();
        }
    }
    private bool IsTouchBegan()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
    private void ShowDialog(int index)
    {
        DialogLine line = dialogLines[index];
        TutorialUIManager.instance.ShowDialog(line.Script);
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
        Debug.Log("Stop! " + currentIndex);
        Time.timeScale = 0.0f;
        TutorialUIManager.instance.OnTutorialCanvas();
        isStop = true;
        ShowDialog(currentIndex);
        switch (currentIndex)
        {
            case 11: 
                infoImageIndex = 0;
                openInfo = true;
                break;
            case 14: 
                infoImageIndex = 1;
                openInfo = true;
                break;
            case 20: 
                infoImageIndex = 2;
                openInfo = true;
                break;
            case 23: 
                infoImageIndex = 3;
                openInfo = true;
                break;
            case 26: 
                infoImageIndex = 4;
                openInfo = true;
                break;
            case 29: 
                infoImageIndex = 5;
                openInfo = true;
                break;
            case 32: 
                infoImageIndex = 6;
                openInfo = true;
                break;
            case 35: 
                infoImageIndex = 7;
                openInfo = true;
                break;
        }
        if (infoImageIndex != -1 && openInfo)
        {
            TutorialUIManager.instance.OpenInfoImage(infoImageIndex);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    private void NextDialog()
    {
        currentIndex++;

        if (currentIndex >= 39)
        {
            currentIndex = 39;
            GameManager.instance.Data.isFirst = false;
            GameManager.instance.SaveData();
        }
        Debug.Log(currentIndex);

        if (currentIndex >= dialogLines.Count)
        {
            TutorialUIManager.instance.OffTutorialCanvas();
            return;
        }

        DialogLine line = dialogLines[currentIndex];

        if (line.Type.Trim().Equals("Dialog", StringComparison.OrdinalIgnoreCase))
        {
            ShowDialog(currentIndex);
        }
        else if (line.Type.Trim().Equals("Event", StringComparison.OrdinalIgnoreCase))
        {
            currentIndex++;
            if (infoImageIndex != -1)
            {
                TutorialUIManager.instance.CloseInfoImage(infoImageIndex);
                openInfo = false;
            }
                
            TutorialUIManager.instance.OffTutorialCanvas();
            isStop = false;
            Resume();
        }

        if (currentIndex == 39)
        {
            TutorialUIManager.instance.ShowStartButton();
        }
    }
}

