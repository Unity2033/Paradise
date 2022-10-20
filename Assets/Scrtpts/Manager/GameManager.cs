using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    private float currentTime;

    public static GameManager instance;

    public bool state;
    public GameObject overPanel;
    public Text _playTime, Curret_Time, Maximum_Time;

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

        currentTime += Time.deltaTime;

        TimeSpan time_span = TimeSpan.FromSeconds(currentTime);

        _playTime.text = time_span.ToString(@"mm\:ss\:ff");

        if(currentTime > PlayerPrefs.GetFloat("Record") )
        {
            Singleton.instance.Record = currentTime;             
            Singleton.instance.DataSave();
        }
           
        Curret_Time.text = time_span.ToString(@"mm\:ss\:ff");
        Maximum_Time.text = Singleton.instance.Record_span.ToString(@"mm\:ss\:ff");        
      
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
