using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IScroll
{
    [SerializeField] private float speed = 20.0f;
    private ScoreManager scoreManager;
    
    public ScoreManager ScoreManager
    {
        get => scoreManager;
    }
    private void Awake()
    {
        GameObject obj = GameObject.Find("ScoreManager");
        obj.TryGetComponent<ScoreManager>(out scoreManager);
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
}
