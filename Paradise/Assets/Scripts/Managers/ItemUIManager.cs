using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    [SerializeField] int itemKey;
    [SerializeField] int previousKey;

    [SerializeField] string[] select;

    private void Awake()
    {
        itemKey = previousKey = 0;

        for (int i = 0; i < 5; i++)
        {
            GameObject.Find(select[i]).GetComponent<Image>().color = Color.gray;
        }
    }
    void Update()
    {
        ClickButton();
    }

    public void ClickButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemKey = 0;
            ChangeColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemKey = 1;
            ChangeColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            itemKey = 2;
            ChangeColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            itemKey = 3;
            ChangeColor();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            itemKey = 4;
            ChangeColor();
        }

        previousKey = itemKey;
    }

    public void ChangeColor()
    {
        if (GameObject.Find(select[itemKey]).transform.GetChild(1).GetComponent<Image>().sprite == null) return;

        GameObject.Find(select[previousKey]).GetComponent<Image>().color = Color.gray;
        GameObject.Find(select[itemKey]).GetComponent<Image>().color = Color.red;
    }
}