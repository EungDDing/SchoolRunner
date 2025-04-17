using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IScroll
{
    private Camera mainCamera;
    [SerializeField] private float speed = 0.0f;
    private ScoreManager scoreManager;
    private ObjectType type;
    private ScrollManager scrollManager;

    public ScoreManager ScoreManager
    {
        get => scoreManager;
    }
    public virtual void Start()
    {
        GameObject obj = GameObject.Find("ScoreManager");
        obj.TryGetComponent<ScoreManager>(out scoreManager);

        mainCamera = Camera.main;

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
        ReturnObject();
    }
    public void SetMain()
    {
        Debug.Log(gameObject.name);
    }
    public void ReturnObject()
    {
        if (Vector3.Distance(mainCamera.transform.position, transform.position) < 5.0f)
        {
            SpawnObjectManager.instance.ReturnObjectToPool(gameObject, (int)type);
        }
    }
    public void SetType(ObjectType newType)
    {
        type = newType;
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
