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

    public state State
    {
        get;
        set;
    } = state.Idle;

    [SerializeField] Text diamond;
    [SerializeField] Text [ ] StairsScore;
    [SerializeField] Canvas [ ] gameCanvas;

    [SerializeField] GameObject character;

    private void Update()
    {
        diamond.text = DataManager.Instance.data.diamond.ToString();

        StairsScore[0].text = DataManager.Instance.CurrentScore.ToString();
        StairsScore[1].text = DataManager.Instance.CurrentScore.ToString();
        StairsScore[2].text = DataManager.Instance.data.statirsMaxScore.ToString();
    }


    public void StateCanvas(state currentState)
    {
        CanvasPriority((int)currentState);

        if (state.Exit == currentState)
        {
             character.GetComponent<Animator>().Play("Death Animation");         
        }
    }

    public void CanvasPriority(int select)
    {
        for(int i = 0; i < gameCanvas.Length; i++)
        {
            gameCanvas[i].planeDistance = 0;
        }

        gameCanvas[select].planeDistance = 1;
    }

    private void OnApplicationQuit()
    {
        DataManager.Instance.Save();
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
