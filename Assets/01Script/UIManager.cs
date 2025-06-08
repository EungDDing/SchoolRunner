using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

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
    [SerializeField] private Button tutorialButton;

    [SerializeField] private Image gameConfigPopup;
    [SerializeField] private Button gameConfigCloseButton;

    [SerializeField] private Image endIamge;
    [SerializeField] private Image gameoverFadeEffect;
    [SerializeField] private Image gameoverImage;

    [SerializeField] private Image pauseMenu;

    [SerializeField] private RectTransform startImage;
    [SerializeField] private RectTransform levelImage;

    private bool isOpenAlbum;
    
    private PlayerController playerController;
    private ScoreManager scoreManager;
    private ItemManager itemManager;
    private AlbumUI albumUI;

    private GameObject obj;
    private GameObject albumPanel;

    public delegate void UIGoLobby();
    public static UIGoLobby OnGoLobby;
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
        tutorialButton.onClick.AddListener(GoTutorial);
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
        playerController.OnChangeCharacter += LevelUp;
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
        playerController.OnChangeCharacter -= LevelUp;
    }
    private void Update()
    {
        OnClickObject();
    }
    public void ChangeDumbbellValue(int value)
    {
        dumbbellValue.text = value.ToString();
        StartCoroutine(TextEffect(dumbbellValue));
    }
    public void ChangeStudyValue(int value)
    {
        bookValue.text = value.ToString();
        StartCoroutine(TextEffect(bookValue));
    }
    public void ChangeSingValue(int value)
    {
        micValue.text = value.ToString();
        StartCoroutine(TextEffect(micValue));
    }
    public void ChangeGameValue(int value)
    {
        gameValue.text = value.ToString();
        StartCoroutine(TextEffect(gameValue));
    }
    private IEnumerator TextEffect(TextMeshProUGUI text)
    {
        Transform textTransform = text.transform;
        Vector3 originalScale = textTransform.localScale;
        Vector3 targetScale = originalScale * 2.0f;

        float time = 0.0f;
        float duration = 0.15f;

        while (time < duration)
        {
            textTransform.localScale = Vector3.Lerp(originalScale, targetScale, time / duration);
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        textTransform.localScale = targetScale;

        time = 0.0f;

        while (time < duration)
        {
            textTransform.localScale = Vector3.Lerp(targetScale, originalScale, time / duration);
            time += Time.unscaledDeltaTime;
            yield return null;
        }

        textTransform.localScale = originalScale;
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
        StartCoroutine(ShowStartImage());
    }
    private IEnumerator ShowStartImage()
    {
        Vector2 start = startImage.anchoredPosition;
        Vector2 end = new Vector2(0.0f, start.y);
        float duration = 0.25f;
        float time = 0.0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            startImage.anchoredPosition = Vector2.Lerp(start, end, time / duration);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        start = startImage.anchoredPosition;
        end = new Vector2(-1000.0f, start.y);
        duration = 0.25f;
        time = 0.0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            startImage.anchoredPosition = Vector2.Lerp(start, end, time / duration);
            yield return null;
        }
    }
    private IEnumerator ShowLevelImage()
    {
        Vector2 basic = levelImage.anchoredPosition;

        Vector2 start = levelImage.anchoredPosition;
        Vector2 end = new Vector2(0.0f, start.y);
        float duration = 0.25f;
        float time = 0.0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            levelImage.anchoredPosition = Vector2.Lerp(start, end, time / duration);
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        start = levelImage.anchoredPosition;
        end = new Vector2(-1000.0f, start.y);
        duration = 0.25f;
        time = 0.0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            levelImage.anchoredPosition = Vector2.Lerp(start, end, time / duration);
            yield return null;
        }

        levelImage.anchoredPosition = basic;
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
        float fadeOutTime = 0.5f;

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
        OnGoLobby?.Invoke();
        GameManager.instance.AsyncLoadNextScene(SceneName.RunningScene);
    }
    public void GoTutorial()
    {
        GameManager.instance.AsyncLoadNextScene(SceneName.TutorialScene);
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

            Ray ray = Camera.main.ScreenPointToRay(inputPosition);
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
    public void LevelUp()
    {
        levelImage.gameObject.SetActive(true);
        StartCoroutine(ShowLevelImage());
    }
}
