using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    private List<IScroll> scrollObjects;
    [SerializeField] private float scrollSpeed = 15.0f;

    private void Awake() 
    {
        scrollObjects = new List<IScroll>();
        MonoBehaviour[] allObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        foreach (var objects in allObjects)
        {
            if (objects is IScroll scrollObject)
            {
                scrollObjects.Add(scrollObject);
            }
        }
    }
    public void AddScrollObject(IScroll scrollObject)
    {
        if (!scrollObjects.Contains(scrollObject))
        {
            scrollObjects.Add(scrollObject);
            scrollObject.SetScrollSpeed(scrollSpeed);
        }
        else
        {
            scrollObject.SetScrollSpeed(scrollSpeed);
        }
    }
    public void RemoveScrollObject(IScroll scrollObject)
    {
        if (scrollObjects.Contains(scrollObject))
        {
            scrollObjects.Remove(scrollObject);
        }
    }
    private void Update()
    {
        foreach (var scroll in new List<IScroll>(scrollObjects))
        {
            if (scroll != null)
            {
                scroll.Scroll();
            }
        }
    }
    public void InitScrollManager(float newSpeed)
    {
        scrollSpeed = newSpeed;
        foreach(var scroll in scrollObjects)
        {
            if (scroll is IScroll scrollObject)
            {
                scrollObject.SetScrollSpeed(newSpeed);
            }    
        }
    }
}
