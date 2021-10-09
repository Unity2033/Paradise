using UnityEngine;

public class external_Switch : MonoBehaviour
{
    public void Store_Button()
    {
        Ui_Size_Control.instacne.Open(() => { }, () => { });
    }

    public void Setting_Button()
    {
        Ui_Size_Control.instacne.Setting_Open(() => { }, () => { });
    }

    public void Cancle_Button()
    {
        Ui_Size_Control.instacne.CancleClick();
    }

    public void Reduction()
    {
        Ui_Size_Control.instacne.Button_Reduction();
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
