using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.U2D;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class BH_GameManager : MonoBehaviour
{
    float current_time, degree;

    public Text Diamond, _playTime, Curret_Time, Maximum_Time;
    public GameObject _reStartButton, Watch;
    public SpriteRenderer Shuttle;

    public Material[] Space;

    [SerializeField] SpriteAtlas Atlas;
    [SerializeField] GameObject Pause_Button;

    void Start()
    {
        _playTime.text = "00 : 00 : 00";

        Singleton.instance.GamePlay = true;
        Advertisement.Initialize("4376819");

        Advertisement.Banner.Hide();

        switch (Singleton.instance.Galaxy_Name)
        {
            case "Kepler-452b":
                RenderSettings.skybox = Space[0];
                break;
            case "Gliese 876":
                RenderSettings.skybox = Space[1];
                break;
            case "Earth":
                RenderSettings.skybox = Space[2];
                break;
        }

        Singleton.instance.Adventure = 1;
        Singleton.instance.SaveData();

        Shuttle.sprite = Atlas.GetSprite(Singleton.instance.Shuttle_Name);
    }

    void Update()
    {
        if (Singleton.instance.GamePlay)
        {
            current_time += Time.deltaTime;

            TimeSpan time_span = TimeSpan.FromSeconds(current_time);
   
            _playTime.text = string.Format("{0:00}:{1:00}:{2:00}", time_span.Hours, time_span.Minutes, time_span.Seconds);

            if(current_time  > PlayerPrefs.GetFloat("Record") )
            {
                Singleton.instance.Record = current_time;
                Singleton.instance.SaveData();
            }

            degree += Time.deltaTime;

            if (degree >= 360) degree = 0;
          
            RenderSettings.skybox.SetFloat("_Rotation", degree);

            Diamond.text = Singleton.instance.Currency.ToString();
            Curret_Time.text = string.Format("{0:00}:{1:00}:{2:00}", time_span.Hours, time_span.Minutes, time_span.Seconds);
            Maximum_Time.text = string.Format("{0:00}:{1:00}:{2:00}", Singleton.instance.Record_span.Hours, Singleton.instance.Record_span.Minutes, Singleton.instance.Record_span.Seconds);
        } 
    }

    public void GameOver()
    {
        if (Advertisement.IsReady("video"))
        {
            Advertisement.Show("video");
        }

        Watch.SetActive(false);
        Pause_Button.SetActive(false);
        _reStartButton.SetActive(true);
        Singleton.instance.GamePlay = false;
        Sound_Manager.instance.Belch_Auido.Stop();        
    }

    public void OnClick_ReStart()
    {
        Sound_Manager.instance.Start_Sound();
        Sound_Manager.instance.Belch_Auido.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
