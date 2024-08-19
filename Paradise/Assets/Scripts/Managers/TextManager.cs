using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] List<string> conversation;
    [SerializeField] List<string> character;

    [SerializeField] WaitForSeconds waitforseconds = new WaitForSeconds(0.05f);
    [SerializeField] Text characterName;
    [SerializeField] Text dialogue;

    [SerializeField] int storyCheck = 3; // 인게임 전후의 스토리를 나누는 기준값
    [SerializeField] bool clickButton = false; // 마우스 클릭 여부 확인(클릭 시 텍스트가 한 번에 출력)

    void Start()
    {
        // 글자가 하나씩 출력되는 코루틴 생성
        StartCoroutine(Beforestory());
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            clickButton = true;
        }
    }

    public IEnumerator Beforestory()
    {
        characterName.text = null;
        dialogue.text = null;

        for(int i = 0; i < storyCheck; i++)
        {
            if(i == 0 || i == 2)
            {
                characterName.text = character[0];
            }
            else
            {
                characterName.text = character[1];
            }

            for (int j = 0; j < conversation[i].Length; j++)
            {
                if (clickButton == true)
                {
                    dialogue.text = conversation[i];
                    clickButton = false;

                    break;
                }

                dialogue.text += conversation[i][j];

                yield return waitforseconds;
            }

            while (true)
            {
                if (clickButton == true)
                {
                    clickButton = false;
                    break;
                }
                yield return null;
            }

            characterName.text = null;
            dialogue.text = null;
        }
        StartCoroutine(Afterstory());
    }

    public IEnumerator Afterstory()
    {
        characterName.text = null;
        dialogue.text = null;
        GameObject data = GameObject.Find("Conversation Box");

        for (int i = storyCheck; i < conversation.Count; i++)
        {
            if (i == 3 || i == 5)
            {
                characterName.text = character[0];
            }
            else
            {
                characterName.text = character[1];
            }

            for (int j = 0; j < conversation[i].Length; j++)
            {
                if (clickButton == true)
                {
                    dialogue.text = conversation[i];
                    clickButton = false;

                    break;
                }

                dialogue.text += conversation[i][j];

                yield return waitforseconds;
            }

            while (true)
            {
                if (clickButton == true)
                {
                    clickButton = false;
                    break;
                }
                yield return null;
            }

            characterName.text = null;
            dialogue.text = null;
        }
        Destroy(data);
    }
}