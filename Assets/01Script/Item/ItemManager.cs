using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private ItemBase itemBase;
    private ItemBase mainCoin;
    private string mainCoinName;
    private bool isMainSet;

    private void Awake()
    {
        mainCoin = null;
        isMainSet = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            itemBase = other.GetComponent<ItemBase>();

            itemBase.ItemGet();  
        }
    }
}
