using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem getItemParticle;

    private ItemBase itemBase;
    private TutorialItem tutorialItem;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            itemBase = other.GetComponent<ItemBase>();
            tutorialItem = other.GetComponent<TutorialItem>();
            getItemParticle.Play();

            if (itemBase != null)
            {
                itemBase.ItemGet();
                itemBase.ReturnObject();
            }
            else if (tutorialItem != null)
            {
                tutorialItem.ItemGet();
            }
        }
    }
}
