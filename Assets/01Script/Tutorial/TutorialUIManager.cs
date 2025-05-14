using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUIManager : MonoBehaviour
{
    [SerializeField] private Image[] heart;

    private PlayerController playerController;
    private GameObject obj;

    private void Awake()
    {
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
}
