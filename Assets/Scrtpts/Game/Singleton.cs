using UnityEngine;
using System;

public class Singleton : MonoBehaviour
{
    public bool GamePlay;
    public Space_Ship[] All_Ship;
    public Space_Ground[] All_Ground;

    public static Sprite Equip;
    public static Material Space_Material;

    public Material Space_Equip;
    public AudioSource BGM_Sound;
    public SpriteRenderer Shuttle;

    public int Gear_Count = 2;
    public int Shuttle_Switch_Count = 0;
    public int Count, Planet_count, Currency = 0;
    public int Language_Count, Sound_count, Switch_Count;

    public static int Connect = 0;

    public float Record, Gear_Speed;
    public static Singleton instance = null;

    public TimeSpan Record_span; 

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(this.gameObject);

        SaveRoad();

        string last_Space = PlayerPrefs.GetString("Space", Space_Ground.Space_Ground_Name.Kepler_452b.ToString());

        foreach (Space_Ground All_Space in All_Ground)
        {
            if (All_Space.space_name.ToString() == last_Space)
            {
                Equip_Space(All_Space);
            }
        }

        string last_Uesd = PlayerPrefs.GetString("Shuttle", Space_Ship.Shuttle_Name.Atlantis.ToString());

        foreach (Space_Ship All_Shuttle in All_Ship)
        {
            if (All_Shuttle.shuttle_name.ToString() == last_Uesd)
            {
                Equip_Shuttle(All_Shuttle);
            }
        }

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
        PlayerPrefs.SetInt("Sound_count", Sound_count);
        PlayerPrefs.SetInt("Planet_count", Planet_count);
        PlayerPrefs.SetInt("Switch_count", Switch_Count);
        PlayerPrefs.SetInt("Language_Count", Language_Count);
        PlayerPrefs.SetInt("Shuttle_Switch_Count", Shuttle_Switch_Count);
    }

    public void SaveRoad()
    {
        Count = PlayerPrefs.GetInt("Count", 0);
        Record = PlayerPrefs.GetFloat("Record", 0f);
        Currency = PlayerPrefs.GetInt("Currency", 0);
        Gear_Count = PlayerPrefs.GetInt("Gear_Count", 2);
        Sound_count = PlayerPrefs.GetInt("Sound_count", 0);
        Planet_count = PlayerPrefs.GetInt("Planet_count", 0);
        Switch_Count = PlayerPrefs.GetInt("Switch_count", 0);
        Language_Count = PlayerPrefs.GetInt("Language_Count", 0);
        Shuttle_Switch_Count = PlayerPrefs.GetInt("Shuttle_Switch_Count", 0);
    }

    public void Equip_Shuttle(Space_Ship Ship)
    {
        Equip = Ship.Shuttle_Sprite;
        PlayerPrefs.SetString("Shuttle", Ship.shuttle_name.ToString());
    }

    public void Equip_Space(Space_Ground Ground)
    {
        Space_Material = Ground.Galaxy;
        PlayerPrefs.SetString("Space", Ground.space_name.ToString());
    }
}
