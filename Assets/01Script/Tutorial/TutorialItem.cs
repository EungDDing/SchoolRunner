using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class TutorialItem : MonoBehaviour
{
    private PlayerController playerController;

    public PlayerController PlayerController
    {
        get => playerController;
    }

    public virtual void Start()
    {
        GameObject obj = GameObject.Find("ScoreManager");
        obj = GameObject.FindWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);
    }
    public abstract void ItemGet();
}
