using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int dumbbell;
    private int book;
    private int mic;
    private int game;

    public delegate void ScoreChange(int value);
    public event ScoreChange OnChangeDumbbell;
    public event ScoreChange OnChangeBook;
    public event ScoreChange OnChangeMic;
    public event ScoreChange OnChangeGame;

    public delegate void GameEnd();
    public event GameEnd OnGameEnd;

    private int stageCount;

    public int StageCount
    {
        get => stageCount;
        set
        {
            stageCount = value;
        }
    }
    private void OnEnable()
    {
        Stage.OnChangeStageCount += CheckStageCount;
    }
    private void OnDisable()
    {
        Stage.OnChangeStageCount -= CheckStageCount;
    }
    public int Dumbbell
    {
        get => dumbbell;
        set
        {
            dumbbell = value;
            if (dumbbell <= 0)
            {
                dumbbell = 0;
            }
            OnChangeDumbbell?.Invoke(dumbbell);
        }
    }
    public int Book
    {
        get => book;
        set
        {
            book = value;
            if (book <= 0)
            {
                book = 0;
            }
            OnChangeBook?.Invoke(book);
        }
    }
    public int Mic
    {
        get => mic;
        set
        {
            mic = value;
            if (mic <= 0)
            {
                mic = 0;
            }
            OnChangeMic?.Invoke(mic);
        }
    }
    public int Game
    {
        get => game;
        set
        {
            game = value;
            if (game <= 0)
            {
                game = 0;
            }
            OnChangeGame?.Invoke(game);
        }
    }
    public void CheckStageCount()
    {
        stageCount++;
        Debug.Log($"[ScoreManager] Stage Count 증가: {stageCount}");
        if (stageCount == 19)
        {
            OnGameEnd?.Invoke();
            CheckResult();
            StartCoroutine(ChangeScene());
        }
    }
    public void InitData()
    {
        Dumbbell = 0;
        Book = 0;
        Mic = 0;
        Game = 0;
        stageCount = 0;
        Debug.Log(Dumbbell);
        Debug.Log(Book);
        Debug.Log(Mic);
        Debug.Log(Game);
    }
    public void CheckResult()
    {
        if (game >= 25)
        {
            GameManager.instance.Data.endings[0].isUnlocked = true;
            GameManager.instance.EndingIndex = 0;
            GameManager.instance.SaveData();
        }
        else if (game >= 15)
        {
            GameManager.instance.Data.endings[6].isUnlocked = true;
            GameManager.instance.EndingIndex = 6;
            GameManager.instance.SaveData();
        }
        else if (book >= 15 && mic >= 15)
        {
            GameManager.instance.Data.endings[4].isUnlocked = true;
            GameManager.instance.EndingIndex = 4;
            GameManager.instance.SaveData();
        }
        else if (book >= 15 && dumbbell >= 15)
        {
            GameManager.instance.Data.endings[5].isUnlocked = true;
            GameManager.instance.EndingIndex = 5;
            GameManager.instance.SaveData();
        }
        else if (book >= 25)
        {
            GameManager.instance.Data.endings[1].isUnlocked = true;
            GameManager.instance.EndingIndex = 1;
            GameManager.instance.SaveData();
        }
        else if (dumbbell >= 25)
        {
            GameManager.instance.Data.endings[3].isUnlocked = true;
            GameManager.instance.EndingIndex = 3;
            GameManager.instance.SaveData();
        }
        else if (mic >= 25)
        {
            GameManager.instance.Data.endings[2].isUnlocked = true;
            GameManager.instance.EndingIndex = 2;
            GameManager.instance.SaveData();
        }
        else
        {
            GameManager.instance.Data.endings[6].isUnlocked = true;
            GameManager.instance.EndingIndex = 6;
            GameManager.instance.SaveData();
        }
    }
    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.instance.AsyncLoadNextScene(SceneName.EndingScene);
    }
}
