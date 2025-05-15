using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIManager : MonoBehaviour
{
    public static TutorialUIManager instance;

    [SerializeField] private Image[] heart;

    [SerializeField] private Canvas tutorialCanvas;
    [SerializeField] private TextMeshProUGUI dialog;
    
    private PlayerController playerController;
    private GameObject obj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);
    }
    private void OnEnable()
    {
        playerController.OnChangeHP += ChangeHeart;
    }
    private void OnDisable()
    {
        playerController.OnChangeHP -= ChangeHeart;
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
    public void OnTutorialCanvas()
    {
        tutorialCanvas.gameObject.SetActive(true);
    }
    public void OffTutorialCanvas()
    {
        tutorialCanvas.gameObject.SetActive(false);
    }
    public void ShowDialog(string text)
    {
        if (!tutorialCanvas.gameObject.activeSelf)
        {
            tutorialCanvas.gameObject.SetActive(true);
        }
        Debug.Log("uimanager show dialog");
        dialog.text = text;
    }
}
