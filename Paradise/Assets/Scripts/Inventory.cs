using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] Transform[] itemTransforms;

    [SerializeField] GameObject itemPrefab;

    [SerializeField] int indexCount = 0;

    [SerializeField] GameObject[] items;

    int selectedKey = -1;
    int previousKey = -1;

    new private void Awake()
    {
        base.Awake();

        for (int i = 0; i < itemTransforms.Length; i++)
        {
            itemTransforms[i].parent.GetComponent<Image>().color = Color.gray;
        }
    }

    public void GetItem(string itemName)
    {
        for (int i = 0; i < items.Length; i++)
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

    public bool UseItem(string destroyItemName)
    {
        if (selectedKey == -1) return false;

        if (destroyItemName == items[selectedKey].name)
        {
            Destroy(items[selectedKey]);

            itemTransforms[selectedKey].parent.GetComponent<Image>().color = Color.gray;

            selectedKey = -1;

            return true;
        }

        return false;
    }

    void Update()
    {
        if (Input.anyKeyDown) ClickButton();   
    }

    public void ClickButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedKey = 0;
            ChangeColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedKey = 1;
            ChangeColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedKey = 2;
            ChangeColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedKey = 3;
            ChangeColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedKey = 4;
            ChangeColor();
        }

        previousKey = selectedKey;
    }

    public void ChangeColor()
    {
        if (items[selectedKey] == null) return;

        if (previousKey != -1) itemTransforms[previousKey].parent.GetComponent<Image>().color = Color.gray;
        itemTransforms[selectedKey].parent.GetComponent<Image>().color = Color.red;
    }
}
