using UnityEngine;
using System;

public class Singleton : MonoBehaviour
{
    public bool GamePlay;
    public Space_Ship[] All_Ship;
    public static Sprite Equip;
    public SpriteRenderer Shuttle;
    public bool Planet_Condition;

    public int Earth, Gliese_876 = 0;
    public int Language_Count, Sound_count = 0;
    public int Count, Planet_count, Currency = 0;

    public float Record;
    public string Galaxy_Name, Shuttle_Name = "";

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
        PlayerPrefs.SetInt("Earth", Earth);
        PlayerPrefs.SetInt("Currency", Currency);

        PlayerPrefs.SetInt("Gliese_876", Gliese_876);

        PlayerPrefs.SetFloat("Record", Record);

        PlayerPrefs.SetInt("Sound_count", Sound_count);
        PlayerPrefs.SetInt("Planet_count", Planet_count);
        PlayerPrefs.SetInt("Language_Count", Language_Count);
    }

    public void SaveRoad()
    {
        Count = PlayerPrefs.GetInt("Count", 0);
        Earth = PlayerPrefs.GetInt("Earth", 0);
        Currency = PlayerPrefs.GetInt("Currency", 0);
        Gliese_876 = PlayerPrefs.GetInt("Gliese_876", 0);

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
}
