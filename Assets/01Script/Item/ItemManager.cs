using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private ItemBase itemBase;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            itemBase = other.GetComponent<ItemBase>();

            itemBase.ItemGet();
            itemBase.ReturnObject();
        }
    }
}
