using Ricimi;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class EndingSceneManager : MonoBehaviour
{
    [SerializeField] private Image endingImage;
    [SerializeField] private Image dialogBackground;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private Button returnButton;
    [SerializeField] private Image fadeEffectImage;
    [SerializeField] private Image endImage;

    private RectTransform imageRectTransform;
    private float time;
    private float percent;
    private float fadeEffectTime = 0.7f;
    private Vector2 firstScene;
    private Vector2 secondScene;
    private Vector2 lastScene = Vector2.zero;
    private Vector2 sceneSize = new Vector2(270, 480);
    private Vector2 fullSize = new Vector2(1080, 1920);
    private int index;
    private void Start()
    {
        index = GameManager.instance.EndingIndex;
        endingImage.TryGetComponent<RectTransform>(out imageRectTransform);
        fadeEffectImage.color = new Color(1, 1, 1, 1f);
        SetPosition();
        StartCoroutine(PlayEnding(index));
    }
    private IEnumerator PlayEnding(int endingIndex)
    {

        StartCoroutine(FadeIn());
        SetEndingImage(endingIndex);
        ShowImagePart(sceneSize, firstScene);
        DisplayScript01(endingIndex);
        
        yield return new WaitForSeconds(3.0f);

        yield return StartCoroutine(FadeOut());
        dialogText.text = "";
        ShowImagePart(sceneSize, secondScene);
        yield return StartCoroutine(FadeIn());
        DisplayScript02(endingIndex);

        yield return new WaitForSeconds(3.0f);

        yield return StartCoroutine(FadeOut());
        dialogText.text = "";
        ShowImagePart(fullSize, lastScene);
        yield return StartCoroutine(FadeIn());
        DisplayScript03(endingIndex);

        yield return new WaitForSeconds(3.0f);
        returnButton.gameObject.SetActive(true);
        endImage.gameObject.SetActive(true);
    }
    private void SetEndingImage(int endingIndex)
    {
        if (DataManager.instance.GetEndingData(endingIndex, out EndingData_Entity endingData))
        {
            endingImage.sprite = Resources.Load<Sprite>(endingData.Image);
        }
    }
    private void DisplayScript01(int endingIndex)
    {
        if (DataManager.instance.GetEndingData(endingIndex, out EndingData_Entity endingData))
        {
            StartCoroutine(PrintText(endingData.Script01));
        }
    }
    private void DisplayScript02(int endingIndex)
    {
        if (DataManager.instance.GetEndingData(endingIndex, out EndingData_Entity endingData))
        {
            StartCoroutine(PrintText(endingData.Script02));
        }
    }
    private void DisplayScript03(int endingIndex)
    {
        if (DataManager.instance.GetEndingData(endingIndex, out EndingData_Entity endingData))
        {
            StartCoroutine(PrintText(endingData.Script03));
        }
    }
    // show a part of UI image
    private void ShowImagePart(Vector2 size, Vector2 pos)
    {
        float targetWidth = size.x;
        float targetHeight = size.y;

        float scaleX = 1080 / targetWidth;
        float scaleY = 1920 / targetHeight;

        if (size == fullSize)
        {
            imageRectTransform.sizeDelta = fullSize;
            imageRectTransform.anchoredPosition = Vector2.zero;
        }
        else
        {
            imageRectTransform.sizeDelta = new Vector2(
                fullSize.x * scaleX,
                fullSize.y * scaleY
            );

            imageRectTransform.anchoredPosition = new Vector2(
                -pos.x * scaleX,
                -pos.y * scaleY
            );
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
    private IEnumerator FadeIn()
    {
        time = 0.0f;
        percent = 0.0f;

        while (percent < 1.0f)
        {
            time += Time.deltaTime;
            percent = time / fadeEffectTime;

            Color color = fadeEffectImage.color;
            color.a = Mathf.Lerp(1, 0, percent);
            fadeEffectImage.color = color;

            yield return null;
        }
    }
    private IEnumerator FadeOut()
    {
        time = 0.0f;
        percent = 0.0f;

        while (percent < 1.0f)
        {
            time += Time.deltaTime;
            percent = time / fadeEffectTime;

            Color color = fadeEffectImage.color;
            color.a = Mathf.Lerp(0, 1, percent);
            fadeEffectImage.color = color;

            yield return null;
        }
    }
    private void SetPosition()
    {
        switch (index)
        {
            case 0:
                SoundManager.instance.ChangeBGM((BGM_Type)index);
                firstScene = new Vector2(-383, 416);
                secondScene = new Vector2(255, 334);
                break;
            case 1:
                SoundManager.instance.ChangeBGM((BGM_Type)index);
                firstScene = new Vector2(-377, 682);
                secondScene = new Vector2(191, -130);
                break;
            case 2:
                SoundManager.instance.ChangeBGM((BGM_Type)index);
                firstScene = new Vector2(-335, 591);
                secondScene = new Vector2(92, -277);
                break;
            case 3:
                SoundManager.instance.ChangeBGM((BGM_Type)index);
                firstScene = new Vector2(331, 297);
                secondScene = new Vector2(-230, -711);
                break;
            case 4:
                SoundManager.instance.ChangeBGM((BGM_Type)index);
                firstScene = new Vector2(-380, -22);
                secondScene = new Vector2(122, -451);
                break;
            case 5:
                SoundManager.instance.ChangeBGM((BGM_Type)index);
                firstScene = new Vector2(-17, -489);
                secondScene = new Vector2(395, 156);
                break;
            case 6:
                SoundManager.instance.ChangeBGM((BGM_Type)index);
                firstScene = new Vector2(-230, -190);
                secondScene = new Vector2(-293, 360);
                break;
        }
    }
}
