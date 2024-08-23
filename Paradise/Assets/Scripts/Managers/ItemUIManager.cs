using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIManager : MonoBehaviour
{
    [SerializeField] int selectedKey;
    [SerializeField] int previousKey;

    [SerializeField] string[] select;

    private void Awake()
    {
        selectedKey = previousKey = 0;

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
        if (GameObject.Find(select[selectedKey]).transform.GetChild(1).GetComponent<Image>().sprite == null) return;

        GameObject.Find(select[previousKey]).GetComponent<Image>().color = Color.gray;
        GameObject.Find(select[selectedKey]).GetComponent<Image>().color = Color.red;
    }
}