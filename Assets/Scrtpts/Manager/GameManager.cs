using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.Advertisements;
using GooglePlayGames;

public class GameManager : MonoBehaviour
{
    float current_time;

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
        Singleton.instance.GamePlay = true;
        Advertisement.Initialize("4376819");

        Advertisement.Banner.Hide();
    }

    void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            current_time += Time.deltaTime;

            TimeSpan time_span = TimeSpan.FromSeconds(current_time);

            _playTime.text = time_span.ToString(@"mm\:ss\:ff");

            if(current_time > PlayerPrefs.GetFloat("Record") )
            {
                Singleton.instance.Record = current_time;             
                Singleton.instance.DataSave();
            }
           
            Diamond.text = Singleton.instance.Currency.ToString();
            Curret_Time.text = time_span.ToString(@"mm\:ss\:ff");
            Maximum_Time.text = Singleton.instance.Record_span.ToString(@"mm\:ss\:ff");        
        } 
    }

    public void GameOver()
    {
        if (Advertisement.IsReady("video"))
        {
             Advertisement.Show("video");
        }        

        Singleton.instance.fullSound.Stop();

        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_4, 1, null);

        Social.ReportScore((long)Singleton.instance.Record_span.TotalMilliseconds, GPGSIds.leaderboard, null);

        Watch.SetActive(false);
        _reStartButton.SetActive(true);
        Singleton.instance.GamePlay = false;
        Sound_Manager.instance.auido.Stop();    
    }
}
