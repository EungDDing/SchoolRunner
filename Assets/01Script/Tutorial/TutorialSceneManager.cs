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
    private void Awake()
    {
        TryGetComponent<DialogReader>(out dialogReader);
        currentIndex = 0;
        isStop = false;
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
        if (Input.GetMouseButtonDown(0) && isStop)
        {
            NextDialog();
        }
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
        Time.timeScale = 0.0f;
        TutorialUIManager.instance.OnTutorialCanvas();
        isStop = true;
        ShowDialog(currentIndex);
    }
    public void Resume()
    {
        Time.timeScale = 1.0f;
    }

    private void NextDialog()
    {
        Debug.Log("다음으로");

        currentIndex++;

        Debug.Log(currentIndex);

        if (currentIndex >= dialogLines.Count)
        {
            TutorialUIManager.instance.OffTutorialCanvas();
            return;
        }

        DialogLine line = dialogLines[currentIndex];

        Debug.Log("line.Type = [" + line.Script + "]");
        Debug.Log("line.Type = [" + line.Type + "]");
        if (line.Type.Trim().Equals("Dialog", StringComparison.OrdinalIgnoreCase))
        {
            Debug.Log("다음 dialog");
            ShowDialog(currentIndex);
        }
        else if (line.Type.Trim().Equals("Event", StringComparison.OrdinalIgnoreCase))
        {
            currentIndex++;
            TutorialUIManager.instance.OffTutorialCanvas();
            isStop = false;
            Resume();
        }
    }
}

