using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private TextMeshProUGUI exerciseValue;
    [SerializeField] private TextMeshProUGUI studyValue;
    [SerializeField] private TextMeshProUGUI singValue;

    private PlayerController playerController;
    private ScoreManager scoreManager;
    private GameObject obj;
    private void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);
        obj = GameObject.Find("ScoreManager");
        obj.TryGetComponent<ScoreManager>(out scoreManager);
    }
    private void OnEnable()
    {
        playerController.OnChangeHP += ChangeHPText;
        scoreManager.OnChangeExercise += ChangeExerciseValue;
        scoreManager.OnChangeStudy += ChangeStudyValue;
        scoreManager.OnChangeSing += ChangeSingValue;
    }
    private void OnDisable()
    {
        playerController.OnChangeHP -= ChangeHPText;
        scoreManager.OnChangeExercise -= ChangeExerciseValue;
        scoreManager.OnChangeStudy -= ChangeStudyValue;
        scoreManager.OnChangeSing -= ChangeSingValue;
    }
    public void ChangeHPText()
    {
        hpText.text = playerController.CurrentHP.ToString();
    }
    public void ChangeExerciseValue(int value)
    {
        exerciseValue.text = value.ToString();
    }
    public void ChangeStudyValue(int value)
    {
        studyValue.text = value.ToString();
    }
    public void ChangeSingValue(int value)
    {
        singValue.text = value.ToString();
    }
}
