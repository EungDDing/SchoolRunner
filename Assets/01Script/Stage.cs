using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum StageNumber
{
    Stage01 = 0,
    Stage02,
    Stage03,
    Stage04,
    Bridge
}

public class Stage : MonoBehaviour, IScroll
{
    [SerializeField] private float scrollSpeed = 0.0f;

    private ScrollManager scrollManager;
    private StageNumber stageNumber;

    public delegate void ChangeStageCount();
    public static event ChangeStageCount OnChangeStageCount;

    public StageNumber StageNumber
    {
        get => stageNumber;
    }
    private void Start()
    {
        SetStageNumber();
    }
    private void Update()
    {
        // Scroll();
    }
    
    public void InitStage()
    {
        StartCoroutine(GetScrollManager());
    }
    private IEnumerator GetScrollManager()
    {
        while (scrollManager == null)
        {
            scrollManager = FindObjectOfType<ScrollManager>();
            yield return null;
        }

        scrollManager.AddScrollObject(this);
    }

    public void Scroll()
    {
        transform.position += -transform.forward * (scrollSpeed * Time.deltaTime);
    }
    public void StartMapControl()
    {
        StartCoroutine(MoveStartMap());
    }
    private IEnumerator MoveStartMap()
    {
        yield return new WaitForSeconds(3.0f);
        scrollSpeed = 20.0f;
    }
    public void SetScrollSpeed(float newSpeed)
    {
        scrollSpeed = newSpeed;
    }
    private void SetStageNumber()
    {
        if (name.Contains("Stage01"))
        {
            stageNumber = StageNumber.Stage01;
        }
        else if (name.Contains("Stage02"))
        {
            stageNumber = StageNumber.Stage02;
        }
        else if (name.Contains("Stage03"))
        {
            stageNumber = StageNumber.Stage03;
        }
        else if (name.Contains("Stage04"))
        {
            stageNumber = StageNumber.Stage04;
        }
        else if (name.Contains("Bridge"))
        {
            stageNumber = StageNumber.Bridge;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnChangeStageCount?.Invoke();
        }
    }
}
