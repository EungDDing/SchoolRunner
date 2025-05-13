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
    private float returnZ = -200.0f;
    private PlayerController playerController;
    public ScoreManager ScoreManager
    {
        get => scoreManager;
    }
    public PlayerController PlayerController
    {
        get => playerController;
    }

    public virtual void Start()
    {
        GameObject obj = GameObject.Find("ScoreManager");
        obj.TryGetComponent<ScoreManager>(out scoreManager);
        obj = GameObject.FindWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);
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
    private void OnEnable()
    {
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
        // Scroll(); 
        if (transform.position.z < returnZ)
        {
            ReturnObject();
        }
    }
    public void SetMain()
    {
        Debug.Log(gameObject.name);
    }
    public void ReturnObject()
    {
        SpawnObjectManager.instance.ReturnObjectToPool(gameObject, (int)type);
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
