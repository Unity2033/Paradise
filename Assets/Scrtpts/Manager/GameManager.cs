using UnityEngine;
using UnityEngine.UI;

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
            case state.Idle : ActivationCanvas(false, 0, true);             
                break;
            case state.Progress : ActivationCanvas(false, 1, true);             
                break;
            case state.Exit : ActivationCanvas(true, 1, false);
                break;
        }
    }

    public void ActivationCanvas(bool active, int disableCount, bool enableActive)
    {
        for(int i = 0; i < gameCanvas.Length; i++)
        {
            gameCanvas[i].SetActive(active);
        }

        gameCanvas[disableCount].SetActive(enableActive);
    }
}
