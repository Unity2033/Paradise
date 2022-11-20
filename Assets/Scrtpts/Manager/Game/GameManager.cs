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
    private float decreaseGauge = 0.0001f;

    public state State
    {
        get { return currentStatus; }
        set { currentStatus = value; }
    }

    [SerializeField] Text diamond;
    [SerializeField] Slider progressBar;
    [SerializeField] Text [] StairsScore;
    [SerializeField] GameObject [] gameCanvas;

    void Start()
    {      
        currentStatus = state.Idle;
    }

    private void Update()
    {
        if(currentStatus == state.Progress)
        {      
            progressBar.value -= decreaseGauge;
        }

        diamond.text = DataManager.Instance.data.diamond.ToString();

        StairsScore[0].text = DataManager.Instance.CurrentScore.ToString();
        StairsScore[1].text = DataManager.Instance.CurrentScore.ToString();
        StairsScore[2].text = DataManager.Instance.data.statirsMaxScore.ToString();
    }

    public void IncreaseGauge()
    {
        if (DataManager.Instance.CurrentScore % 5 == 0)
        {
            decreaseGauge += 0.00005f;
        }
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


    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
