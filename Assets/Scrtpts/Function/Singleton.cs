using UnityEngine;
using System;

public class Singleton : MonoBehaviour
{
    public AudioSource fullSound;

    public int Shuttle_Switch_Count = 0;
    public int Planet_count, Currency = 0;

    public static int Connect = 0;

    public static Singleton instance = null;

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

    public void DataSave()
    {      
        PlayerPrefs.SetInt("Currency", Currency);
        PlayerPrefs.SetInt("Planet_count", Planet_count);
        PlayerPrefs.SetInt("Shuttle_Switch_Count", Shuttle_Switch_Count);
    }

    public void DataLoad()
    {
        Currency = PlayerPrefs.GetInt("Currency", 0);
        Planet_count = PlayerPrefs.GetInt("Planet_count", 0);
        Shuttle_Switch_Count = PlayerPrefs.GetInt("Shuttle_Switch_Count", 0);
    }
}
