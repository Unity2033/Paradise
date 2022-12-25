using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using GooglePlayGames;

public class CreateButtonManager : MonoBehaviour
{
    [SerializeField] GameObject window;
    [SerializeField] Transform parentPosition;
    [SerializeField] Sprite [] sprite;

    private List<GameObject> button = new List<GameObject>();

    private void Start()
    {
        CreateButton(3);

        button[0].GetComponent<Button>().onClick.AddListener(WindowToggle);
        button[1].GetComponent<Button>().onClick.AddListener(Achievement);
        button[2].GetComponent<Button>().onClick.AddListener(LeaderBoard);
    }

    private void CreateButton(int createCount)
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject buttonPrefab = Instantiate(Resources.Load<GameObject>("Versatile Button"));

            button.Add(buttonPrefab);

            button[i].transform.SetParent(parentPosition);
            button[i].GetComponent<Image>().sprite = sprite[i];
            button[i].transform.localScale = new Vector3(1, 1, 1);
            button[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(-550 + (i * 300), -1200);
        }
    }

    public void WindowToggle()
    {
        SoundManager.Instance.Sound(1);

        window.SetActive(true);
    }


    public void Achievement()
    {
        if (Social.localUser.authenticated == false)
        {
            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Social.ShowAchievementsUI();
                    return;
                }
                else
                {
                    return;
                }
            });
        }

        Social.ShowAchievementsUI();
    }

    public void LeaderBoard()
    {
        if (Social.localUser.authenticated == false)
        {
            Social.ReportScore
            (
                DataManager.Instance.data.statirsMaxScore, "CgkIhLHxpZoVEAIQDQ",
                (bool success) =>
                {
                    if (success)
                    {
                        ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard);
                    }
                }

            );

            Social.localUser.Authenticate((bool success) =>
            {
                if (success)
                {
                    Social.ShowLeaderboardUI();

                    ((PlayGamesPlatform)Social.Active).ShowLeaderboardUI(GPGSIds.leaderboard);
                    return;
                }
                else
                {
                    return;
                }
            });
        }

        Social.ShowLeaderboardUI();
    }

}
