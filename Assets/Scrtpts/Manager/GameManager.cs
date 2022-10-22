using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool state;
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
        state = true;

        Advertisement.Initialize("4376819");

        Advertisement.Banner.Hide();
    }

    public void Update()
    {
        if (state == false) return;
          
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
