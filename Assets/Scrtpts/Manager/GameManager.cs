using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum state
    {
        IDLE,
        EXECUTION,
        END
    };

    public state currentStatus;

    public state State
    {
        get { return currentStatus; }
        set { currentStatus = value; }
    }

    public GameObject overPanel;
    public Text stairsNumber, CurretStairsNumber, MaximumStairsNumber;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentStatus = state.IDLE;
    }


    public void GameOver()
    {
        if (Advertisement.IsReady("video"))
        {
             Advertisement.Show("video");
        }        

        Singleton.instance.fullSound.Stop();

        overPanel.SetActive(true);   
    }
}
