using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

[System.Serializable]
public class Planet
{
    public Sprite Ground;
}

public class Item_Choice : MonoBehaviour
{
    [SerializeField] SpriteAtlas Atlas;

    [SerializeField] Image Space_Back = null;
    [SerializeField] Image Store_Space_Ship = null;
    [SerializeField] Planet [] Planet_Array = null;
    [SerializeField] Button Character_Button = null;

    [SerializeField] Space_Ship[] Shuttle;

    public Button [] Purchase;
    public Button Sound_Setting;
    [SerializeField] Text Diamond;
    public bool Locked;

    public Material[] Sky;

    private void Start()
    {
        Unlocked();

        if (Singleton.instance.Gliese_876 == 1)
        {
            Social.ReportProgress(GPGSIds.achievement, 100, null);
        }

        switch (Singleton.instance.Planet_count)
        {
            case 0:
                Sound_Manager.instance.Play_Music("Connection");
                break;
            case 1 : Sound_Function(Singleton.instance.Gliese_876, Singleton.instance.Earth, Singleton.instance.Planet_Condition, "A little Star", "Connection", "Star");
                break;
            case 2 : Sound_Function(Singleton.instance.Earth, Singleton.instance.Gliese_876, Singleton.instance.Planet_Condition, "Star", "A little Star", "Connection");
                break;
        }
    }

    void Unlocked()
    {
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetInt(Shuttle[i].shuttle_name.ToString()) == 1)
            {
                Locked = true;
            }
        }
    }


    void Sound_Function(int instance, int instnace_1, bool Condition , string Music, string Music_1, string Music_2)
    {
        if (instance == 1)
        {
            Sound_Manager.instance.Play_Music(Music);
        }
        else if (instance == 0 && instnace_1 == 1)
        {
            if (Condition == true)
            {
                Sound_Manager.instance.Play_Music(Music_1);
            }
            else if (Condition == false)
            {
                Sound_Manager.instance.Play_Music(Music_2);
            }
        }
        else if (instance == 0 && instnace_1 == 0)
        {
            Sound_Manager.instance.Play_Music("Connection");
        }
    }

    private void Update()
    {
        Change_Planet();

        Diamond.text = Singleton.instance.Currency.ToString();

        switch (Singleton.instance.Language_Count)
        {
            case 0:
                Localize.SetCurrentLanguage(SystemLanguage.Korean);
                break;
            case 1:
                Localize.SetCurrentLanguage(SystemLanguage.English);
                break;
            case 2:
                Localize.SetCurrentLanguage(SystemLanguage.Japanese);
                break;
            case 3:
                Localize.SetCurrentLanguage(SystemLanguage.Vietnamese);
                break;
        }

        RenderSettings.skybox.SetFloat("_Rotation", 0);

        if (Singleton.instance.Sound_count == 0)
        {
            AudioListener.volume = 1;
            Sound_Setting.GetComponent<Image>().sprite = Atlas.GetSprite("Sound on");
        }
        else
        {
            AudioListener.volume = 0;
            Sound_Setting.GetComponent<Image>().sprite = Atlas.GetSprite("Sound off");
        }

        switch (Singleton.instance.Planet_count)
        {
            case 0:
                Purchase[1].gameObject.SetActive(false);
                break;
            case 1 : Store_Function(Singleton.instance.Gliese_876, Singleton.instance.Currency, 1, 300, "Buy Now 300");
                break;
            case 2 : Store_Function(Singleton.instance.Earth, Singleton.instance.Currency, 1, 500, "Buy Now 500");
                break;
        }
    }

    void Store_Function(int Item,int Currency,int Array,int Price,string Sprite_Name)
    {
        if (Item == 1)
        {
            Purchase[Array].interactable = false;
            Purchase[Array].gameObject.SetActive(false);
        }
        else if (Currency < Price)
        {
            Purchase[Array].interactable = false;
            Purchase[Array].gameObject.SetActive(true);
            Purchase[Array].GetComponent<Image>().sprite = Atlas.GetSprite(Sprite_Name);
        }
        else if (Currency >= Price)
        {
            Purchase[Array].interactable = true;
            Purchase[Array].gameObject.SetActive(true);
            Purchase[Array].GetComponent<Image>().sprite = Atlas.GetSprite(Sprite_Name);
        }
    }

    public void Shuttle_Right_Button()
    {
        Singleton.instance.Shuttle_Condition = true;

        if(++Singleton.instance.Count > Shuttle.Length - 1)
            Singleton.instance.Count = 0;

        switch (Singleton.instance.Count)
        {
            case 0:
                Purchase[0].gameObject.SetActive(false);
                Singleton.Equip = Shuttle[Singleton.instance.Count].Shuttle_Sprite;
                Store_Space_Ship.sprite = Shuttle[Singleton.instance.Count].Shuttle_Sprite;
                PlayerPrefs.SetString("Shuttle", Space_Ship.Shuttle_Name.Atlantis.ToString());
                break;
            case 1:
                Store_Space_Ship.sprite = Shuttle[Singleton.instance.Count].Shuttle_Sprite;
                Purchase[0].GetComponent<Image>().sprite = Atlas.GetSprite("Buy Now 300");

                if (Locked)
                {
                    Purchase[0].interactable = false;
                    Purchase[0].gameObject.SetActive(false);

                    Singleton.Equip = Shuttle[1].Shuttle_Sprite;
                    PlayerPrefs.SetString("Shuttle", Space_Ship.Shuttle_Name.Discovery.ToString());
                }
                else
                {
                    Purchase[0].interactable = false;
                    Purchase[0].gameObject.SetActive(true);

                    if (Singleton.instance.Purchase(Shuttle[1].Price))
                    {
                        Unlocked();

                        Purchase[0].interactable = true;
                        Purchase[0].gameObject.SetActive(true);

                        PlayerPrefs.SetInt(Space_Ship.Shuttle_Name.Discovery.ToString(), 1);
                    }
                }
                break;
            case 2:
                Store_Space_Ship.sprite = Shuttle[Singleton.instance.Count].Shuttle_Sprite;
                Purchase[0].GetComponent<Image>().sprite = Atlas.GetSprite("Buy Now 500");

                if (Locked)
                {
                    Purchase[0].interactable = false;
                    Purchase[0].gameObject.SetActive(false);
                    Singleton.Equip = Shuttle[2].Shuttle_Sprite;
                    PlayerPrefs.SetString("Shuttle", Space_Ship.Shuttle_Name.Endeavour.ToString());
                }
                else
                {
                    Purchase[0].interactable = false;
                    Purchase[0].gameObject.SetActive(true);

                    if (Singleton.instance.Purchase(Shuttle[2].Price))
                    {
                        Unlocked();
                        Purchase[0].interactable = true;
                        Purchase[0].gameObject.SetActive(true);
                        PlayerPrefs.SetInt(Space_Ship.Shuttle_Name.Endeavour.ToString(), 1);
                    }
                }
                break;
        }

        Singleton.instance.SaveData();
    }

    public void Shuttle_Left_Button()
    {
        Singleton.instance.Shuttle_Condition = false;

        if (--Singleton.instance.Count < 0)
        

        Singleton.instance.SaveData();
    }

    public void Planet_Right_Button()
    {
       Singleton.instance.Planet_Condition = true;

        if (++Singleton.instance.Planet_count > Planet_Array.Length - 1)
            Singleton.instance.Planet_count = 0;

        Change_Song();
        Change_Planet();
    }

    public void Planet_Left_Button()
    {
        Singleton.instance.Planet_Condition = false;

        if (--Singleton.instance.Planet_count < 0)
            Singleton.instance.Planet_count = Planet_Array.Length - 1;

        Change_Song();
        Change_Planet();

        Singleton.instance.SaveData();
    }

    public void Sound_Button()
    {     
        if (++Singleton.instance.Sound_count == 1)
        {
           AudioListener.volume = 0;
           Sound_Setting.GetComponent<Image>().sprite = Atlas.GetSprite("Sound off");
        }

        if (Singleton.instance.Sound_count == 2)
        {
            AudioListener.volume = 1;
            Singleton.instance.Sound_count = 0;
            Sound_Setting.GetComponent<Image>().sprite = Atlas.GetSprite("Sound on");
        }

        Singleton.instance.SaveData();
    }


    public void Galaxy_Purchase()
    {
        Sound_Manager.instance.Setting_Sound();

        switch (Singleton.instance.Planet_count)
        {
            case 1 :
                Singleton.instance.Gliese_876++;
                Singleton.instance.Currency -= 300;
              
                Sound_Manager.instance.Play_Music("A little Star");

                RenderSettings.skybox = Sky[1];
                Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count].Ground;
                break;
            case 2:
                Singleton.instance.Earth++;
                Singleton.instance.Currency -= 500;

                Sound_Manager.instance.Play_Music("Star");

                RenderSettings.skybox = Sky[2];
                Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count].Ground;
                break;
        }

        Singleton.instance.SaveData();
    }

    void Change_Planet()
    {
        Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count].Ground;

        switch (Singleton.instance.Planet_count)
        {
            case 0:
                RenderSettings.skybox = Sky[0];
                Singleton.instance.Galaxy_Name = "Kepler-452b";
                Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 0].Ground;
                break;
            case 1:
                if (Singleton.instance.Gliese_876 == 1 && Singleton.instance.Earth == 1)
                {
                    RenderSettings.skybox = Sky[1];
                    Singleton.instance.Galaxy_Name = "Gliese 876";
                    Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 1].Ground;
                }
                else if(Singleton.instance.Gliese_876 == 1 && Singleton.instance.Earth == 0)
                {
                    RenderSettings.skybox = Sky[1];
                    Singleton.instance.Galaxy_Name = "Gliese 876";
                    Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 1].Ground;
                }
                else if (Singleton.instance.Gliese_876 == 0 && Singleton.instance.Earth == 1)
                {
                    if(Singleton.instance.Planet_Condition == true)
                    {
                        RenderSettings.skybox = Sky[0];
                        Singleton.instance.Galaxy_Name = "Kepler-452b";
                        Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 1].Ground;
                    }
                    else if(Singleton.instance.Planet_Condition == false)
                    {
                        RenderSettings.skybox = Sky[2];
                        Singleton.instance.Galaxy_Name = "Earth";                    
                        Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 1].Ground;
                    }
                }
                else if (Singleton.instance.Gliese_876 == 0 && Singleton.instance.Earth == 0)
                {
                    RenderSettings.skybox = Sky[0];
                    Singleton.instance.Galaxy_Name = "Kepler-452b";
                }
                break;
            case 2:
                if (Singleton.instance.Gliese_876 == 1 && Singleton.instance.Earth == 1)
                {
                    RenderSettings.skybox = Sky[2];
                    Singleton.instance.Galaxy_Name = "Earth";
                    Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 2].Ground;
                }
                else if (Singleton.instance.Gliese_876 == 1 && Singleton.instance.Earth == 0)
                {
                    if (Singleton.instance.Planet_Condition == true)
                    {
                        RenderSettings.skybox = Sky[1];
                        Singleton.instance.Galaxy_Name = "Gliese 876";
                        Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 2].Ground;
                    }
                    else if (Singleton.instance.Planet_Condition == false)
                    {
                        RenderSettings.skybox = Sky[0];
                        Singleton.instance.Galaxy_Name = "Kepler-452b";
                        Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 2].Ground;
                    }
                }
                else if (Singleton.instance.Gliese_876 == 0 && Singleton.instance.Earth == 1)
                {
                    RenderSettings.skybox = Sky[2];
                    Singleton.instance.Galaxy_Name = "Earth";
                    Space_Back.sprite = Planet_Array[Singleton.instance.Planet_count = 2].Ground;        
                }
                else if (Singleton.instance.Gliese_876 == 0 && Singleton.instance.Earth == 0)
                {
                    RenderSettings.skybox = Sky[0];
                    Singleton.instance.Galaxy_Name = "Kepler-452b";                 
                }
                break;
        }

        Singleton.instance.SaveData();
    }

    void Change_Song()
    {    
        switch (Singleton.instance.Planet_count)
        {
            case 0:
                if (Singleton.instance.Gliese_876 == 1 || Singleton.instance.Earth == 1)
                {
                    Sound_Manager.instance.Play_Music("Connection");
                }
                break;
            case 1:
                if (Singleton.instance.Gliese_876 == 1)
                {
                    Sound_Manager.instance.Play_Music("A little Star");
                }
                break;
            case 2:
                if (Singleton.instance.Earth == 1)
                {
                    Sound_Manager.instance.Play_Music("Star");
                }
                break;
        }

        Singleton.instance.SaveData();
    }


    public void Changed_Shuttle()
    {
        
    }
}
