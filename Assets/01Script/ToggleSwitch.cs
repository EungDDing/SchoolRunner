using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    [SerializeField] private Image handleImage;
    [SerializeField] private TextMeshProUGUI stateText;

    private RectTransform handleTransform;
    private Vector2 onPosition = new Vector3(42.5f, 0.0f);
    private Vector2 offPosition = new Vector3(-87.5f, 0.0f);
    private bool isOn = true;
    private float fillAmount;
    private float fillSpeed = 20.0f;
    private string on = "ON";
    private string off = "OFF";

    private SoundType soundType;
    private void Start()
    {
        if (gameObject.name == "BGMBackground")
        {
            soundType = SoundType.BGM;
        }
        else if (gameObject.name == "SFXBackground")
        {
            soundType = SoundType.SFX;
        }

        if (soundType == SoundType.BGM)
        {
            isOn = GameManager.instance.Data.bgm;
        }
        else if (soundType == SoundType.SFX)
        {
            isOn = GameManager.instance.Data.sfx;
        }

        Debug.Log(soundType);
        handleTransform = handleImage.GetComponent<RectTransform>();
        handleTransform.anchoredPosition = isOn ? onPosition : offPosition;

        fillAmount = isOn ? 1.0f : 0.0f;
        fillImage.fillAmount = fillAmount;

        stateText.text = isOn ? on : off;
    }
    public void Toggle()
    {
        isOn = !isOn;

        if (soundType == SoundType.BGM)
        {
            GameManager.instance.Data.bgm = isOn;
            GameManager.instance.SaveData();
        }
        else if (soundType == SoundType.SFX)
        {
            GameManager.instance.Data.sfx = isOn;
            GameManager.instance.SaveData();
        }

        Debug.Log(stateText.text);
        fillAmount = isOn ? 1.0f : 0.0f;

        Vector2 targetPos = isOn ? onPosition : offPosition;

        stateText.text = isOn ? on : off;

        StopAllCoroutines();
        StartCoroutine(ChangeState(targetPos));
    }
    private IEnumerator ChangeState(Vector2 targetPos)
    {
        while (Vector2.Distance(handleTransform.anchoredPosition, targetPos) > 0.1f)
        {
            handleTransform.anchoredPosition = Vector2.Lerp(handleTransform.anchoredPosition, targetPos, Time.unscaledDeltaTime * fillSpeed);
            fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, fillAmount, Time.unscaledDeltaTime * fillSpeed);
            yield return null;
        }
        handleTransform.anchoredPosition = targetPos;
        fillImage.fillAmount = fillAmount;
    }
}
