using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] int minutes = 10;
    [SerializeField] int seconds = 00;

    Text text;

    [SerializeField] Transform canvas;

    bool isTimerAllowed;

    private void Start()
    {
        text = GetComponent<Text>();

        text.text = string.Format("{0}:{1}", minutes, seconds);

        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        WaitForSeconds second = new WaitForSeconds(1);

        while (minutes != 0 || seconds != 0)
        {
            foreach (Transform child in canvas)
            {
                if (child.gameObject.activeSelf)
                {
                    isTimerAllowed = false;

                    break;
                }
                else isTimerAllowed = true; 
            }

            if (isTimerAllowed) 
            {
                if (seconds > 0) seconds--;
                else
                {
                    seconds = 59;
                    minutes--;
                }

                text.text = string.Format("{0}:{1}", minutes, seconds);
            }

            yield return second;
        }

        Debug.Log("Game Over");    
    }
}
