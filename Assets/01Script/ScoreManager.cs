using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int exercise;
    private int study;
    private int sing;

    public delegate void ScoreChange(int value);
    public event ScoreChange OnChangeExercise;
    public event ScoreChange OnChangeStudy;
    public event ScoreChange OnChangeSing;
    public int Exercise
    {
        get => exercise;
        set
        {
            exercise = value;
            OnChangeExercise?.Invoke(exercise);
        }
    }
    public int Study
    {
        get => study;
        set
        {
            study = value;
            OnChangeStudy?.Invoke(study);
        }
    }
    public int Sing
    {
        get => sing;
        set
        {
            sing = value;
            OnChangeSing?.Invoke(sing);
        }
    }
    public void InitData()
    {
        Exercise = 0;
        Study = 0;
        Sing = 0;
        Debug.Log(Exercise);
        Debug.Log(Study);
        Debug.Log(Sing);
    }
}
