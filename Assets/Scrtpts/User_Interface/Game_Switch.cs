using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Switch : MonoBehaviour
{
    [SerializeField] float count = 3;
    [SerializeField] GameObject Pause_Button;

    readonly WaitForSeconds second = new WaitForSeconds(1f);

    public Text restart;
    public bool condition = false;
    
    public GameObject Pause_Window;

    private void Start()
    {
        Pause_Button.gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        if (condition == true)
        {
            restart.fontSize -= 6;

            if (restart.fontSize == -6)
            {
                restart.fontSize = 300;
            }

            if (count <= 0)
            {
                count = 3;
                condition = false;
                restart.fontSize = 300;
                Singleton.instance.GamePlay = true;           
            }
        }  
    }

    public void Count_Down()
    {
        condition = true;
        Pause_Window.SetActive(false);
        restart.gameObject.SetActive(true);
        StartCoroutine(Count_Down_Start());     
    }

    IEnumerator Count_Down_Start()
    {
        while(count > 0)
        {
            restart.text = Mathf.Round(count).ToString();

            Sound_Manager.instance.Count_Sound();

            AudioListener.pause = false;

            yield return second;

            count--;
        }
   
        Pause_Button.SetActive(true);
        restart.gameObject.SetActive(false);
    }

    public void Pause_true()
    {
        Pause_Window.SetActive(true);
        Pause_Button.SetActive(false);
        Singleton.instance.GamePlay = false;
        AudioListener.pause = true;
    }


}
