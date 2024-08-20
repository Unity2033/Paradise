using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] Transform [] itemTransforms;

    [SerializeField] GameObject itemPrefab;

    [SerializeField] int indexCount = 0;

    [SerializeField] GameObject [] items;  

    public bool ConfirmItem(string itemName)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].name == itemName)
            {
                UseItem(itemName);
                return true; 
            }
        
        }

        return false;
    }

    public void GetItem(string itemName)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                indexCount = i;
                items[i] = Instantiate(itemPrefab, itemTransforms[indexCount]);
                items[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(itemName);

                items[i].name = itemName;

                break;
            }
        }
    }

    public void UseItem(string destroyItemName)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if(destroyItemName == items[i].name)
            {
                Destroy(items[i]);
                break;
            }
        }
    }
}
