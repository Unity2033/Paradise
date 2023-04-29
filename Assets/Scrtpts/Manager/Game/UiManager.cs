using GooglePlayGames;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    public void GameStart()
    {
        SoundManager.Instance.Sound(SoundType.Start);

        GameManager.Instance.StateCanvas(GameManager.state.Progress);
    }

    public void SceneInitialization()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
