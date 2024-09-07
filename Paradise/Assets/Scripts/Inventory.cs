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

    int keyNumber = -1;

    new private void Awake()
    {
        base.Awake();
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

            itemTransforms[selectedKey].GetComponent<Image>().color = new Color(1, 1, 1);

            selectedKey = -1;

            previousKey = -1;

            return true;
        }

        return false;
    }

    void Update()
    {
        if (Input.anyKeyDown) ClickButton(Input.inputString);   
    }

    public void ClickButton(string keyString)
    {
        if (!int.TryParse(keyString, out keyNumber)) return;

        if (keyNumber < 1 || keyNumber > 5) return;

        KeyCode keyCode = KeyCode.Alpha0 + keyNumber;

        if (!Input.GetKeyDown(keyCode)) return;

        selectedKey = keyNumber - 1;

        if (selectedKey == previousKey)
        {
            itemTransforms[selectedKey].GetComponent<Image>().color = new Color(1, 1, 1);

            previousKey = -1;

            selectedKey = -1;
        }
        else
        {
            ChangeColor();

            previousKey = selectedKey;
        }
    }

        public void ChangeColor()
    {
        if (items[selectedKey] == null)
        {
            selectedKey = previousKey;
            return;
        }

        if (previousKey != -1)
        {
            itemTransforms[previousKey].GetComponent<Image>().color = new Color(1, 1, 1);
        }

        itemTransforms[selectedKey].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);
    }
}
