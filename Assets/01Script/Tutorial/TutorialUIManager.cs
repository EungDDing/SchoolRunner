using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIManager : MonoBehaviour
{
    public static TutorialUIManager instance;

    [SerializeField] private Image[] heart;

    [SerializeField] private Canvas middleCanvas;
    [SerializeField] private Canvas frontCanvas;
    [SerializeField] private TextMeshProUGUI dialog;

    [SerializeField] private List<Image> infoImage;
    [SerializeField] private Button startButton;

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
        middleCanvas.gameObject.SetActive(true);
        frontCanvas.gameObject.SetActive(true);
    }
    public void OffTutorialCanvas()
    {
        middleCanvas.gameObject.SetActive(false);
        frontCanvas.gameObject.SetActive(false);
    }
    public void ShowDialog(string text)
    {
        if (!middleCanvas.gameObject.activeSelf)
        {
            middleCanvas.gameObject.SetActive(true);
            frontCanvas.gameObject.SetActive(true);
        }
        Debug.Log("uimanager show dialog");
        dialog.text = text;
    }
    public void OpenInfoImage(int index)
    {
        infoImage[index].gameObject.SetActive(true);
    }
    public void CloseInfoImage(int index)
    {
        Debug.Log("Close info");
        infoImage[index].gameObject.SetActive(false);
    }
    public void ShowStartButton()
    {
        startButton.gameObject.SetActive(true);
    }
    public void GoLobby()
    {
        GameManager.instance.AsyncLoadNextScene(SceneName.RunningScene);
    }
}
