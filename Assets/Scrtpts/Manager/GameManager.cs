using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using GooglePlayGames;

public class GameManager : MonoBehaviour
{
    private float currentTime;

    public static GameManager instance;

    public int itemState = -1;
    public GameObject _reStartButton, Watch;
    public Text Diamond, _playTime, Curret_Time, Maximum_Time;

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
        Singleton.instance.state = true;

        Advertisement.Initialize("4376819");

        Advertisement.Banner.Hide();
    }

    public void Update()
    {
        if (Singleton.instance.state == false) return;
 
        currentTime += Time.deltaTime;

        TimeSpan time_span = TimeSpan.FromSeconds(currentTime);

        _playTime.text = time_span.ToString(@"mm\:ss\:ff");

        if(currentTime > PlayerPrefs.GetFloat("Record") )
        {
            Singleton.instance.Record = currentTime;             
            Singleton.instance.DataSave();
        }
           
        Diamond.text = Singleton.instance.Currency.ToString();
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

       // Social.ReportScore((long)Singleton.instance.Record_span.TotalMilliseconds, GPGSIds.leaderboard, null);

        Watch.SetActive(false);
        _reStartButton.SetActive(true);
        Singleton.instance.state = false;
        Sound_Manager.instance.auido.Stop();    
    }
}
