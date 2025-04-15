using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject dumbbellCoinUI;
    [SerializeField] private GameObject bookCoinUI;
    [SerializeField] private GameObject micCoinUI;
    [SerializeField] private GameObject gameCoinUI;

    [SerializeField] private TextMeshProUGUI dumbbellValue;
    [SerializeField] private TextMeshProUGUI bookValue;
    [SerializeField] private TextMeshProUGUI gameValue;
    [SerializeField] private TextMeshProUGUI micValue;

    [SerializeField] private Image[] heart;

    private PlayerController playerController;
    private ScoreManager scoreManager;
    private ItemManager itemManager;

    private GameObject obj;
    private void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);
        obj.TryGetComponent<ItemManager>(out itemManager);
        obj = GameObject.Find("ScoreManager");
        obj.TryGetComponent<ScoreManager>(out scoreManager);
       
    }
    private void OnEnable()
    {
        scoreManager.OnChangeDumbbell += ChangeDumbbellValue;
        scoreManager.OnChangeBook += ChangeStudyValue;
        scoreManager.OnChangeMic += ChangeSingValue;
        scoreManager.OnChangeGame += ChangeGameValue;
        playerController.OnChangeHP += ChangeHeart;
    }
    private void OnDisable()
    {
        scoreManager.OnChangeDumbbell -= ChangeDumbbellValue;
        scoreManager.OnChangeBook -= ChangeStudyValue;
        scoreManager.OnChangeMic -= ChangeSingValue;
        scoreManager.OnChangeGame -= ChangeGameValue;
        playerController.OnChangeHP -= ChangeHeart;
    }
    public void ChangeDumbbellValue(int value)
    {
        dumbbellValue.text = value.ToString();
    }
    public void ChangeStudyValue(int value)
    {
        bookValue.text = value.ToString();
    }
    public void ChangeSingValue(int value)
    {
        micValue.text = value.ToString();
    }
    public void ChangeGameValue(int value)
    {
        gameValue.text = value.ToString();
    }
    public void ChangeHeart(int hp)
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < hp)
            {
                heart[i].enabled = true;
            }
            else
            {
                heart[i].enabled = false;
            }
        }
    }
}
