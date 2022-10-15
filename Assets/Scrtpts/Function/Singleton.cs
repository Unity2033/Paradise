using UnityEngine;
using System;

public class Singleton : MonoBehaviour
{
    public bool GamePlay;
    public AudioSource fullSound;

    public int Shuttle_Switch_Count = 0;
    public int Count, Planet_count, Currency = 0;

    public static int Connect = 0;

    public float Record;
    public static Singleton instance = null;

    public TimeSpan Record_span; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DataLoad();

        DontDestroyOnLoad(this.gameObject);      
    }

    private void Start()
    {
        fullSound.Play();
    }

    private void Update()
    {
        Record_span = TimeSpan.FromSeconds(Record);
    }

    public void DataSave()
    {      
        PlayerPrefs.SetInt("Count", Count);
        PlayerPrefs.SetFloat("Record", Record);
        PlayerPrefs.SetInt("Currency", Currency);
        PlayerPrefs.SetInt("Planet_count", Planet_count);
        PlayerPrefs.SetInt("Shuttle_Switch_Count", Shuttle_Switch_Count);
    }

    public void DataLoad()
    {
        Count = PlayerPrefs.GetInt("Count", 0);
        Record = PlayerPrefs.GetFloat("Record", 0f);
        Currency = PlayerPrefs.GetInt("Currency", 0);
        Planet_count = PlayerPrefs.GetInt("Planet_count", 0);
        Shuttle_Switch_Count = PlayerPrefs.GetInt("Shuttle_Switch_Count", 0);
    }
}
