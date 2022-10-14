using UnityEngine;
using System;

public class Singleton : MonoBehaviour
{
    public bool GamePlay;

    public static Sprite Equip;
    public static Material Space_Material;

    public Material Space_Equip;
    public AudioSource BGM_Sound;
    public SpriteRenderer Shuttle;

    public int Gear_Count = 2;
    public int Shuttle_Switch_Count = 0;
    public int Count, Planet_count, Currency = 0;
    public int Switch_Count;

    public static int Connect = 0;

    public float Record, Gear_Speed;
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

        SaveRoad();

        DontDestroyOnLoad(this.gameObject);      
    }

    private void Start()
    {
        BGM_Sound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Shuttle.sprite = Equip;
        RenderSettings.skybox = Space_Equip = Space_Material;
        Record_span = TimeSpan.FromSeconds(Record);
    }

    public void SaveData()
    {      
        PlayerPrefs.SetInt("Count", Count);
        PlayerPrefs.SetFloat("Record", Record);
        PlayerPrefs.SetInt("Currency", Currency);
        PlayerPrefs.SetInt("Gear_Count", Gear_Count);
        PlayerPrefs.SetInt("Planet_count", Planet_count);
        PlayerPrefs.SetInt("Switch_count", Switch_Count);
        PlayerPrefs.SetInt("Shuttle_Switch_Count", Shuttle_Switch_Count);
    }

    public void SaveRoad()
    {
        Count = PlayerPrefs.GetInt("Count", 0);
        Record = PlayerPrefs.GetFloat("Record", 0f);
        Currency = PlayerPrefs.GetInt("Currency", 0);
        Gear_Count = PlayerPrefs.GetInt("Gear_Count", 2);
        Planet_count = PlayerPrefs.GetInt("Planet_count", 0);
        Switch_Count = PlayerPrefs.GetInt("Switch_count", 0);
        Shuttle_Switch_Count = PlayerPrefs.GetInt("Shuttle_Switch_Count", 0);
    }
}
