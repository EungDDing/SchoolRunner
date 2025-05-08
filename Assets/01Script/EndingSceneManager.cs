using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndingSceneManager : MonoBehaviour
{
    [SerializeField] private Image endingImage;
    [SerializeField] private Image dialogBackground;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Button returnButton;
    private void Start()
    {
        int endingIndex = GameManager.instance.EndingIndex;
        StartCoroutine(PlayEnding(endingIndex));
    }
    private IEnumerator PlayEnding(int endingIndex)
    {
        DisplayEndingImage(endingIndex);

        yield return new WaitForSeconds(2.0f);

        DisplayDialog(endingIndex);

        yield return new WaitForSeconds(2.0f);

        returnButton.gameObject.SetActive(true);
    }
    private void DisplayEndingImage(int endingIndex)
    {
        if (DataManager.instance.GetEndingData(endingIndex, out EndingData_Entity endingData))
        {
            endingImage.sprite = Resources.Load<Sprite>(endingData.Image);
            Debug.Log(endingData.Script);
        }
    }
    private void DisplayDialog(int endingIndex)
    {
        dialogBackground.gameObject.SetActive(true);

        if (DataManager.instance.GetEndingData(endingIndex, out EndingData_Entity endingData))
        {
            StartCoroutine(PrintText(endingData.Script));
        }
    }
    private IEnumerator PrintText(string text)
    {
        dialogText.text = "";
        foreach (char c in text)
        {
            dialogText.text += c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void GoLobby()
    {
        GameManager.instance.AsyncLoadNextScene(SceneName.RunningScene);
    }
}
