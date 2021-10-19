using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] Ui_Size_Control Ui_Control;

    public void Scene_Move(int index)
    {
        switch (index)
        {
            case 0:
                StartCoroutine(Load_Scene(index));
                AudioListener.pause = false;
                break;
            case 1:
                Sound_Manager.instance.Start_Sound();   
                StartCoroutine(Load_Scene(index));
                break;
            case 2:
                Singleton.instance.BGM_Sound.Play();
                Sound_Manager.instance.Start_Sound();
                Sound_Manager.instance.Belch_Auido.Play();
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
            yield return null;

            switch(Number)
            {
                case 0 :
                    if (Async.progress >= 0.9f)
                    {
                        Async.allowSceneActivation = true;
                    }
                    break;
                case 1 :
                    if (Async.progress >= 0.9f && Ui_Control.Start_animator.GetCurrentAnimatorStateInfo(0).IsName("close"))
                    {
                        Async.allowSceneActivation = true;
                    }
                    break;
            }
        }
    }
}
