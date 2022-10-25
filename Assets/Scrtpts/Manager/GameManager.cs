using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    public Text stairsNumber, CurretStairsNumber, MaximumStairsNumber;
   
    [SerializeField] GameObject [] gameCanvas;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentStatus = state.Idle;
    }

    public void StateCanvas()
    {
        switch (currentStatus)
        {
            case state.Idle :
                {
                    gameCanvas[0].SetActive(true);
                    gameCanvas[1].SetActive(false);
                }
                break;
            case state.Progress :
                {
                    gameCanvas[0].SetActive(false);
                    gameCanvas[1].SetActive(true);
                }
                break;
            case state.Exit :
                {
                    gameCanvas[2].SetActive(true);
                    DataManager.instance.fullSound.Stop();
                }
                break;
        }
    }
}
