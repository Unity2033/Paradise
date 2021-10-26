using UnityEngine;
using UnityEngine.UI;

public class Ui_Size_Control : MonoBehaviour
{
    Animator Store_animator, Setting_animator;
    Animator Title_animator, Store_Button_animator, Setting_Button_animator, Mission_Button_animator, Leaderboard_animator, Reward_animator;

    public Animator Start_animator;

    public Button Launch;
    public GameObject Store_Window, Setting_Window;
    public GameObject Title, Start_Button, Store_Button, Setting_Button, Mission_Button, Leaderboard_Button, Reward_Button;

    readonly string Close = "close";

    public static Ui_Size_Control instacne { get; private set; }

    private void Awake()
    {
        instacne = this;

        Title_animator = Title.GetComponent<Animator>();
        Start_animator = Start_Button.GetComponent<Animator>();
        Reward_animator = Reward_Button.GetComponent<Animator>();
        Store_Button_animator = Store_Button.GetComponent<Animator>();
        Setting_Button_animator = Setting_Button.GetComponent<Animator>();
        Mission_Button_animator = Mission_Button.GetComponent<Animator>();
        Leaderboard_animator = Leaderboard_Button.GetComponent<Animator>();

        Store_animator = Store_Window.GetComponent<Animator>();
        Setting_animator = Setting_Window.GetComponent<Animator>();   
    }

    private void Update()
    {
        if (Store_animator.GetCurrentAnimatorStateInfo(0).IsName(Close) || Setting_animator.GetCurrentAnimatorStateInfo(0).IsName(Close) )
        {
            if (Store_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 || Setting_animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
            {
                Store_Window.SetActive(false);
                Setting_Window.SetActive(false);
            }
        }
    }

    public void Open()
    {
        Window_Function(true, false, false);
        Sound_Manager.instance.Button_Sound();
    }

    public void Setting_Open()
    {
        Window_Function(false, true, false);
        Sound_Manager.instance.Button_Sound();
    }

    void Window_Function(bool Store, bool Setting,bool Play)
    {
        Launch.interactable = Play;
        Store_Window.SetActive(Store);
        Setting_Window.SetActive(Setting);
    }

    public void CancleClick()
    {
        Launch.interactable = true;
        Store_animator.SetTrigger(Close);
        Setting_animator.SetTrigger(Close);

        Sound_Manager.instance.Cancle_Sound();
    }

    public void Button_Reduction()
    {
        Title_animator.SetTrigger(Close);
        Start_animator.SetTrigger(Close);
        Reward_animator.SetTrigger(Close);
        Store_Button_animator.SetTrigger(Close);
        Setting_Button_animator.SetTrigger(Close);
        Mission_Button_animator.SetTrigger(Close);
        Leaderboard_animator.SetTrigger(Close);
    }
}
