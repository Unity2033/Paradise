using UnityEngine;
using UnityEngine.UI;

public class VersatileButton : MonoBehaviour
{

    public void Open(GameObject window)
    {
        window.SetActive(true);
        window.GetComponent<Animator>().Rebind();

        Sound_Manager.instance.Sound(1);
    }

    public void Cancle(GameObject window)
    {
        window.GetComponent<Animator>().SetTrigger("close");

        Sound_Manager.instance.Sound(3);
    }

    public void Language()
    {
        Sound_Manager.instance.Sound(5);

        if (++Singleton.instance.Language_Count == 4)
        {
            Singleton.instance.Language_Count = 0;
        }

        Singleton.instance.SaveData();
    }

    public void Exit()
    {
        Singleton.instance.SaveData();
        Application.Quit();
    }
}
