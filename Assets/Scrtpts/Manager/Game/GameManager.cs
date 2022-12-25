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
    [SerializeField] GameObject [ ] gameCanvas;

    [SerializeField] SpaceShip character;

    private void Update()
    {
        diamond.text = DataManager.Instance.data.diamond.ToString();

        StairsScore[0].text = DataManager.Instance.CurrentScore.ToString();
        StairsScore[1].text = DataManager.Instance.CurrentScore.ToString();
        StairsScore[2].text = DataManager.Instance.data.statirsMaxScore.ToString();
    }


    public void StateCanvas(state currentState)
    {
        switch (currentState)
        {
            case state.Idle :
            {
                    ActivationCanvas(0);

                    break;
            }
            case state.Progress :
            {
                    ActivationCanvas(1);

                    break;
            }
            case state.Exit :
            {
                    ActivationCanvas(2);
                    character.animator.Play("Death Animation");
                    break;
            }
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
