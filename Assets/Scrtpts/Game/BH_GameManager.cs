using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.Analytics;
using UnityEngine.Advertisements;
using GooglePlayGames;

public class BH_GameManager : MonoBehaviour
{
    float current_time, degree;

    public Text Diamond, _playTime, Curret_Time, Maximum_Time;
    public GameObject _reStartButton, Watch;

    [SerializeField] GameObject Pause_Button;

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
                Singleton.instance.SaveData();
            }
         
            degree += Time.deltaTime;
            if (degree >= 360) degree = 0;     
            RenderSettings.skybox.SetFloat("_Rotation", degree);

            Diamond.text = Singleton.instance.Currency.ToString();
            Curret_Time.text = time_span.ToString(@"mm\:ss\:ff");
            Maximum_Time.text = Singleton.instance.Record_span.ToString(@"mm\:ss\:ff");        
        } 
    }

    public void GameOver()
    {
        if (UnityEngine.Random.Range(1,100) <= 50)
        {
            if (Advertisement.IsReady("video"))
            {
                Advertisement.Show("video");
            }
        }

        Singleton.instance.BGM_Sound.Stop();

        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_4, 1, null);

        AnalyticsResult analytics= Analytics.CustomEvent("Death",
            new Dictionary<string, object> {
                { "Currency", Singleton.instance.Currency },
                { "Survival Time", Singleton.instance.Record_span}
            });

        Social.ReportScore((long)Singleton.instance.Record_span.TotalMilliseconds, GPGSIds.leaderboard, null);

        Watch.SetActive(false);
        Pause_Button.SetActive(false);
        _reStartButton.SetActive(true);
        Singleton.instance.GamePlay = false;
        Sound_Manager.instance.Belch_Auido.Stop();    
    }
}
