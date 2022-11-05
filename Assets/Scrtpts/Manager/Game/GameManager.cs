using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public enum state
    {
        Idle,
        Progress,
        Exit
    };

    private state currentStatus;

    public state State
    {
        get { return currentStatus; }
        set { currentStatus = value; }
    }

    public Text CurretStairsNumber, MaximumStairsNumber, CurretStairs;
   
    [SerializeField] GameObject [] gameCanvas;

    void Start()
    {      
        currentStatus = state.Idle;
    }

    private void Update()
    {
        CurretStairs.text = DataManager.Instance.CurrentScore.ToString();
        CurretStairsNumber.text = DataManager.Instance.CurrentScore.ToString();
        MaximumStairsNumber.text = DataManager.Instance.data.statirsMaxScore.ToString();
    }

    public void StateCanvas()
    {
        switch (currentStatus)
        {
            case state.Idle : ActivationCanvas(0);             
                break;
            case state.Progress : ActivationCanvas(1);             
                break;
            case state.Exit : ActivationCanvas(2);
                break;
        }
    }

    public void ActivationCanvas(int selectActive)
    {
        for(int i = 0; i < gameCanvas.Length; i++)
        {
            gameCanvas[i].SetActive(false);
        }

        gameCanvas[selectActive].SetActive(true);
    }
}
