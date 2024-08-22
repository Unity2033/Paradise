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

    [SerializeField] bool beforeStroyCheck = false;

    [SerializeField] GameObject storyPopUp;

    public bool BeforeStroyCheck
    {
        get { return beforeStroyCheck; }
    }

    void Update()
    {
        if(storyPopUp.activeSelf && Input.GetButtonDown("Fire1"))
        {
            clickButton = true;
        }
    }

    public IEnumerator Beforestory()
    {
        storyPopUp.SetActive(true);

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
                GameManager.Instance.State = false;

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

        GameManager.Instance.State = true;

        beforeStroyCheck = true;

        storyPopUp.SetActive(false);
    }

    public IEnumerator Afterstory()
    {
        storyPopUp.SetActive(true);

        characterName.text = null;
        dialogue.text = null;

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

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}