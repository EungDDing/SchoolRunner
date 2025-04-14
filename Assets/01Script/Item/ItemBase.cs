using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IScroll
{
    [SerializeField] private float speed = 0.0f;
    private ScoreManager scoreManager;

    private ScrollManager scrollManager;

    public ScoreManager ScoreManager
    {
        get => scoreManager;
    }
    private void Start()
    {
        GameObject obj = GameObject.Find("ScoreManager");
        obj.TryGetComponent<ScoreManager>(out scoreManager);
    }
    private void OnEnable()
    {
        if (scrollManager == null)
        {
            scrollManager = FindObjectOfType<ScrollManager>();
        }

        if (scrollManager != null)
        {
            scrollManager.AddScrollObject(this);
        }
    }
    private void OnDisable()
    {
        if (scrollManager != null)
        {
            scrollManager.RemoveScrollObject(this);
        }
    }
    private void Update()
    {
        Scroll();
    }
    public void SetMain()
    {
        Debug.Log(gameObject.name);
    }
    public abstract void ItemGet();
    // interface
    public void Scroll()
    {
        transform.position += -Vector3.forward * (speed * Time.deltaTime);
    }

    public void SetScrollSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
