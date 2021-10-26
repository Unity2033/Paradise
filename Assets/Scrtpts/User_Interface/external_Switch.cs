using UnityEngine;

public class external_Switch : MonoBehaviour
{
    public void User_Interface_Open(string Name)
    {
        switch (Name)
        {
            case "Store" :
                Ui_Size_Control.instacne.Open();
                break;
            case "Setting":
                Ui_Size_Control.instacne.Setting_Open();
                break;
            case "Cancle":
                Ui_Size_Control.instacne.CancleClick();
                break;
            case "Reduction":
                Ui_Size_Control.instacne.Button_Reduction();
                break;
        }
    }

    public void Language()
    {
        Sound_Manager.instance.Setting_Sound();

        if (++Singleton.instance.Language_Count == 4)
        {
            Singleton.instance.Language_Count = 0;
        }

        Singleton.instance.SaveData();
    }

    public void Game_End()
    {
        Singleton.instance.SaveData();
        Application.Quit();
    }
}
