using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private Image welcomeText;
    [SerializeField] private GameObject createPlayerPopup;
    [SerializeField] private TMP_InputField idInputField;
    private bool hasPlayerInfo;
    private void Start()
    {
        InitTitleScene();
        StartCoroutine(BlinkWelcomeText());
        idInputField.onValueChanged.AddListener(FilteringKorean);
    }
    private void InitTitleScene()
    {
        if (GameManager.instance.TryGetPlayerData())
        {
            hasPlayerInfo = true;
        }
        else
        {
            hasPlayerInfo = false;
        }
    }
    public void EnterButton()
    {
        if (hasPlayerInfo)
        {
            if (GameManager.instance.Data.isFirst)
            {
                GameManager.instance.AsyncLoadNextScene(SceneName.TutorialScene);
            }
            else
            {
                GameManager.instance.AsyncLoadNextScene(SceneName.RunningScene);
            }
        }
        else
        {
            LeanTween.scale(createPlayerPopup, Vector3.one, 0.7f).setEase(LeanTweenType.easeOutElastic);
        }
    }
    public void DeleteButton()
    {
        GameManager.instance.DeleteData();
        InitTitleScene();
    }
    private string newID;
    public void InputFieldID(string inputID)
    {
        newID = inputID;
    }
    public void ApplyButton()
    {
        if (newID != null && newID.Length >= 2)
        {
            LeanTween.scale(createPlayerPopup, Vector3.zero, 0.7f).setEase(LeanTweenType.easeOutElastic);
            GameManager.instance.CreatePlayerData(newID);
            GameManager.instance.SaveData();
            InitTitleScene();
        }
    }
    private IEnumerator BlinkWelcomeText()
    {
        while (true)
        {
            welcomeText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.7f);
            welcomeText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.7f);
        }
    }
    private void FilteringKorean(string input)
    {
        string filtered = System.Text.RegularExpressions.Regex.Replace(input, @"[\u1100-\u11FF\uAC00-\uD7AF\u3130-\u318F]", "");
        if (filtered != input)
        {
            idInputField.text = filtered;
        }
    }
}
