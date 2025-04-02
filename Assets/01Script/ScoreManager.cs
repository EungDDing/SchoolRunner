using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    public void InitData()
    {
        Dumbbell = 0;
        Book = 0;
        Mic = 0;
        Game = 0;
        Debug.Log(Dumbbell);
        Debug.Log(Book);
        Debug.Log(Mic);
        Debug.Log(Game);
    }
}
