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
    [SerializeField] GameObject[] actualItems;

    [SerializeField] Transform hand;

    [SerializeField] int selectedKey = -1;
    [SerializeField] int previousKey = -1;

    int keyNumber = -1;

    new private void Awake()
    {
        base.Awake();

        hand = transform.parent.Find("Hand");
    }

    public void GetItem(string itemName, GameObject item)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                indexCount = i;
                items[i] = Instantiate(itemPrefab, itemTransforms[indexCount]);
                items[i].GetComponent<Image>().sprite = Resources.Load<Sprite>(itemName);

                items[i].name = itemName;

                actualItems[i] = item;

                actualItems[i].transform.SetParent(hand);
                actualItems[i].transform.localPosition = Vector3.zero;
                actualItems[i].transform.localRotation = Quaternion.identity;

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

            Destroy(actualItems[selectedKey]);

            itemTransforms[selectedKey].GetComponent<Image>().color = new Color(1, 1, 1);

            previousKey = -1;

            selectedKey = -1;

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

        if (selectedKey == previousKey) UnequipItem();
        else EquipItem();
    }

    public void EquipItem()
    {
        if (items[selectedKey] == null)
        {
            selectedKey = previousKey;

            return;
        }

        if (previousKey != -1)
        {
            itemTransforms[previousKey].GetComponent<Image>().color = new Color(1, 1, 1);

            actualItems[previousKey].SetActive(false);
        }

        itemTransforms[selectedKey].GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f);

        actualItems[selectedKey].SetActive(true);

        previousKey = selectedKey;
    }

    public void UnequipItem()
    {
        itemTransforms[selectedKey].GetComponent<Image>().color = new Color(1, 1, 1);

        actualItems[selectedKey].SetActive(false);

        previousKey = -1;

        selectedKey = -1;
    }
}
