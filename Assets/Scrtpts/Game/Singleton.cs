using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Singleton : MonoBehaviour
{
    public bool GamePlay;
    public bool Planet_Condition, Shuttle_Condition;

    public int Earth, Gliese_876 = 0;
    public int Endeavour, Challenger = 0;
    public int Language_Count, Sound_count = 0;
    public int Count, Planet_count, Currency = 0;

    public int Adventure, Quest_Barrier, Quest_Slow, Quest_Turret = 0;

    public float Record;
    public string Galaxy_Name, Shuttle_Name = "";

    public static Singleton instance = null;

    public TimeSpan Record_span; 

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);
   
           SaveRoad();

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Record_span = TimeSpan.FromSeconds(Record);
    }

    public void SaveData()
    {      
        PlayerPrefs.SetInt("Count", Count);
        PlayerPrefs.SetInt("Earth", Earth);
        PlayerPrefs.SetInt("Currency", Currency);
        PlayerPrefs.SetInt("Endeavour", Endeavour);
        PlayerPrefs.SetInt("Challenger", Challenger);

        PlayerPrefs.SetInt("Gliese_876", Gliese_876);

        PlayerPrefs.SetFloat("Record", Record);

        PlayerPrefs.SetInt("Adventure", Adventure);
        PlayerPrefs.SetInt("Quest_Barrier", Quest_Barrier);
        PlayerPrefs.SetInt("Quest_Slow", Quest_Slow);
        PlayerPrefs.SetInt("Quest_Turret", Quest_Turret);

        PlayerPrefs.SetInt("Sound_count", Sound_count);
        PlayerPrefs.SetInt("Planet_count", Planet_count);
        PlayerPrefs.SetInt("Language_Count", Language_Count);
    }

    public void SaveRoad()
    {
        Count = PlayerPrefs.GetInt("Count", 0);
        Earth = PlayerPrefs.GetInt("Earth", 0);
        Currency = PlayerPrefs.GetInt("Currency", 0);
        Endeavour = PlayerPrefs.GetInt("Endeavour", 0);
        Challenger = PlayerPrefs.GetInt("Challenger", 0);
        Gliese_876 = PlayerPrefs.GetInt("Gliese_876", 0);

        Record = PlayerPrefs.GetFloat("Record", 0f);

        Adventure = PlayerPrefs.GetInt("Adventure", 0);
        Quest_Barrier = PlayerPrefs.GetInt("Quest_Barrier", 0);
        Quest_Slow = PlayerPrefs.GetInt("Quest_Slow", 0);
        Quest_Turret = PlayerPrefs.GetInt("Quest_Turret", 0);

        Sound_count = PlayerPrefs.GetInt("Sound_count", 0);
        Planet_count = PlayerPrefs.GetInt("Planet_count", 0);
        Language_Count = PlayerPrefs.GetInt("Language_Count", 0);
    }

}
