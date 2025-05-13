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

    [SerializeField] private Button startButton;

    [SerializeField] private Canvas runCanvas;
    [SerializeField] private Canvas lobbyCanvas;

    [SerializeField] private Image configPopup;
    [SerializeField] private Button configButton;
    [SerializeField] private Button configCloseButton;

    [SerializeField] private Image gameConfigPopup;
    [SerializeField] private Button gameConfigCloseButton;

    [SerializeField] private Image endIamge;
    [SerializeField] private Image gameoverFadeEffect;
    [SerializeField] private Image gameoverImage;

    [SerializeField] private Image pauseMenu;

    private bool isOpenAlbum;
    
    private PlayerController playerController;
    private ScoreManager scoreManager;
    private ItemManager itemManager;
    private AlbumUI albumUI;

    private GameObject obj;
    private GameObject albumPanel;

    private void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);
        obj.TryGetComponent<ItemManager>(out itemManager);
        obj = GameObject.Find("ScoreManager");
        obj.TryGetComponent<ScoreManager>(out scoreManager);
        obj = GameObject.Find("StageManager");
        if (albumPanel == null)
        {
            albumPanel = GameObject.Find("AlbumPanel");
            if (albumPanel && albumPanel.TryGetComponent<AlbumUI>(out albumUI))
            { 
                isOpenAlbum = false;
            }
        }
    }
    private void Start()
    {
        startButton.onClick.AddListener(ChangeCanvas);

        configButton.onClick.AddListener(OpenConfigPopup);
        configCloseButton.onClick.AddListener(CloseConfigPopup);
    }
    private void OnEnable()
    {
        scoreManager.OnChangeDumbbell += ChangeDumbbellValue;
        scoreManager.OnChangeBook += ChangeStudyValue;
        scoreManager.OnChangeMic += ChangeSingValue;
        scoreManager.OnChangeGame += ChangeGameValue;
        playerController.OnChangeHP += ChangeHeart;
        scoreManager.OnGameEnd += FadeOutScreen;
        playerController.OnGameOver += GameOver;
    }
    private void OnDisable()
    {
        scoreManager.OnChangeDumbbell -= ChangeDumbbellValue;
        scoreManager.OnChangeBook -= ChangeStudyValue;
        scoreManager.OnChangeMic -= ChangeSingValue;
        scoreManager.OnChangeGame -= ChangeGameValue;
        playerController.OnChangeHP -= ChangeHeart;
        scoreManager.OnGameEnd -= FadeOutScreen;
        playerController.OnGameOver -= GameOver;
    }
    private void Update()
    {
        OnClickObject();
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
    public void OpenConfigPopup()
    {
        configPopup.gameObject.SetActive(true);
        gameConfigPopup.gameObject.SetActive(true);
    }
    public void CloseConfigPopup()
    {
        configPopup.gameObject.SetActive(false);
        gameConfigPopup.gameObject.SetActive(false);
    }
    private void ChangeCanvas()
    {
        lobbyCanvas.gameObject.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(OnRunCanvas());
    }
    private IEnumerator OnRunCanvas()
    {
        yield return new WaitForSeconds(3.0f);
        runCanvas.gameObject.SetActive(true);
    }
    public void ShowAlbum()
    {
        isOpenAlbum = !isOpenAlbum;
        if (isOpenAlbum)
        {
            albumPanel.LeanScale(Vector3.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
            albumUI.RefreshAlbum();
        }
    }
    private void FadeOutScreen()
    {
        StartCoroutine(FadeOut());
    }
    private IEnumerator FadeOut()
    {
        float time = 0.0f;
        float percent = 0.0f;
        float fadeOutTime = 2.0f;

        while (percent < 1.0f)
        {
            time += Time.deltaTime;
            percent = time / fadeOutTime;

            Color color = endIamge.color;
            color.a = Mathf.Lerp(0, 1, percent);
            endIamge.color = color;

            yield return null;
        }

    }
    public void CloseAlbumPanel()
    {
        isOpenAlbum = !isOpenAlbum;
        albumPanel.LeanScale(Vector3.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
    }
    public void GameOver()
    {
        StartCoroutine(GameOverEffect());
    }
    private IEnumerator GameOverEffect()
    {
        float time = 0.0f;
        float percent = 0.0f;
        float fadeEffectTime = 1.0f;

        while (percent < 1.0f)
        {
            time += Time.deltaTime;
            percent = time / fadeEffectTime;

            Color color = gameoverFadeEffect.color;
            color.a = Mathf.Lerp(0, 1, percent);
            gameoverFadeEffect.color = color;

            yield return null;
        }

        gameoverImage.gameObject.SetActive(true);
        
        time = 0.0f;
        percent = 0.0f;
        while (percent < 1.0f)
        {
            time += Time.deltaTime;
            percent = time / fadeEffectTime;

            Color color = gameoverFadeEffect.color;
            color.a = Mathf.Lerp(1, 0, percent);
            gameoverFadeEffect.color = color;

            yield return null;
        }
        gameoverFadeEffect.gameObject.SetActive(false);
    }
    public void GoLobby()
    {
        GameManager.instance.AsyncLoadNextScene(SceneName.RunningScene);
    }
    public void OpenPauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void ClosePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
    }
    public void OnClickObject()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            Vector3 inputPosition = Vector3.zero;

            if (Input.GetMouseButtonDown(0))
            {
                inputPosition = Input.mousePosition;
            }
            else if (Input.touchCount > 0)
            {
                inputPosition = Input.GetTouch(0).position;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 50.0f))
            {
                if (hit.collider.CompareTag("Config"))
                {
                    OpenConfigPopup();
                }
                else if(hit.collider.CompareTag("Album"))
                {
                    ShowAlbum();
                }
            }
        }
    }
}
