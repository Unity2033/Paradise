using UnityEngine;
using System;

public class Singleton : MonoBehaviour
{
    public bool GamePlay;
    public Space_Ship[] All_Ship;
    public Space_Ground[] All_Ground;

    public static Sprite Equip;
    public SpriteRenderer Shuttle;

    public int Language_Count, Sound_count = 0;
    public int Count, Planet_count, Currency = 0;

    public float Record;

    public static Singleton instance = null;
    public static int Connect = 0;

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

    public bool Purchase(int Calculate)
    {
        if(Currency >= Calculate)
        {
            Currency -= Calculate;
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Update()
    {
        Shuttle.sprite = Equip;
        Record_span = TimeSpan.FromSeconds(Record);
    }

    public void SaveData()
    {      
        PlayerPrefs.SetInt("Count", Count);
        PlayerPrefs.SetInt("Currency", Currency);

        PlayerPrefs.SetFloat("Record", Record);

        PlayerPrefs.SetInt("Sound_count", Sound_count);
        PlayerPrefs.SetInt("Planet_count", Planet_count);
        PlayerPrefs.SetInt("Language_Count", Language_Count);
    }

    public void SaveRoad()
    {
        Count = PlayerPrefs.GetInt("Count", 0);
        Currency = PlayerPrefs.GetInt("Currency", 0);

        Record = PlayerPrefs.GetFloat("Record", 0f);

        Sound_count = PlayerPrefs.GetInt("Sound_count", 0);
        Planet_count = PlayerPrefs.GetInt("Planet_count", 0);
        Language_Count = PlayerPrefs.GetInt("Language_Count", 0);
    }

    public void Equip_Shuttle(Space_Ship Ship)
    {
        Equip = Ship.Shuttle_Sprite;
        PlayerPrefs.SetString("Shuttle", Ship.shuttle_name.ToString());
    }

    public void Equip_Space(Space_Ground Ground)
    {
        RenderSettings.skybox = Ground.Galaxy;
        PlayerPrefs.SetString("Space", Ground.space_name.ToString());
    }
}
