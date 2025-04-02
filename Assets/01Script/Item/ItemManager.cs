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

    public delegate void SetMainCoin(string name);
    public event SetMainCoin OnSetMain;

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

            if (isMainSet == false)
            {
                isMainSet = true;
                mainCoin = itemBase;
                itemBase.SetMain();
                OnSetMain?.Invoke(mainCoin.gameObject.name);
                mainCoinName = mainCoin.gameObject.name;
                Destroy(mainCoin.gameObject);
            }
            else
            {
                if (itemBase.gameObject.name == mainCoinName)
                {
                    itemBase.ItemGet(true);
                }
                else
                {
                    itemBase.ItemGet(false);
                }
            }    
        }
    }
}
