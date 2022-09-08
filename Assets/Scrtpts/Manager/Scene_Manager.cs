using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void Scene_Move(int index)
    {
        switch (index)
        {
            case 0:
                StartCoroutine(Load_Scene(index));
                AudioListener.pause = false;
                break;
            case 1:
                Sound_Manager.instance.Sound(3);   
                StartCoroutine(Load_Scene(index));
                break;
            case 2:
                Sound_Manager.instance.Sound(3);
                Singleton.instance.BGM_Sound.Play();
                Sound_Manager.instance.auido.Play();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;
        }
    }
   
    IEnumerator Load_Scene(int Number)
    {
        AsyncOperation Async = SceneManager.LoadSceneAsync(Number);

        Async.allowSceneActivation = false;

        while (!Async.isDone)
        {
            if (Async.progress >= 0.9f)
            {
                Async.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
