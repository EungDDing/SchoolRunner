using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI welcomeText;
    [SerializeField] private GameObject createPlayerPopup;

    private bool hasPlayerInfo;
    private void Start()
    {
        InitTitleScene();
        StartCoroutine(BlinkWelcomeText());
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
            GameManager.instance.AsyncLoadNextScene(SceneName.RunningScene);
            Debug.Log(GameManager.instance.Data.playerID);
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
            welcomeText.enabled = !welcomeText.enabled;
            yield return new WaitForSeconds(0.7f);
        }
    }
}
