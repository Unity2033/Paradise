using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using GooglePlayGames;

public class TitleButton : CreateButton
{
    [SerializeField] GameObject window;
 
    private List<GameObject> button = new List<GameObject>();

    private void Start()
    {
        Create(3, "Title Button");

        button[0].GetComponent<Button>().onClick.AddListener(Function1);
        button[1].GetComponent<Button>().onClick.AddListener(Function2);
        button[2].GetComponent<Button>().onClick.AddListener(Function3);
    }

    public override void Create(int createCount, string buttonName)
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject buttonPrefab = Instantiate(Resources.Load<GameObject>(buttonName));

            button.Add(buttonPrefab);

            button[i].transform.SetParent(parentPosition);
            button[i].GetComponent<Image>().sprite = sprite[i];
            button[i].transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public override void Function1()
    {
        SoundManager.Instance.Sound(SoundType.Open);

        window.SetActive(true);
    }

    public override void Function2()
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

    public override void Function3()
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
