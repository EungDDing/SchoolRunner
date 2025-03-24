using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hpText;
    private PlayerController playerController;
    private GameObject obj;
    private void Awake()
    {
        obj = GameObject.FindGameObjectWithTag("Player");
        obj.TryGetComponent<PlayerController>(out playerController);
    }
    private void OnEnable()
    {
        playerController.OnChangeHP += ChangeHPText;
    }
    private void OnDisable()
    {
        playerController.OnChangeHP -= ChangeHPText;
    }
    public void ChangeHPText()
    {
        hpText.text = playerController.CurrentHP.ToString();
    }
}
