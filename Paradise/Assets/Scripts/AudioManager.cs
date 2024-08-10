using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Sound
{ 
    Scenery,
}


public class AudioManager : MonoBehaviour
{
    [SerializeField] Sound sound;
    [SerializeField] AudioSource effectSource;
    [SerializeField] AudioSource scenerySource;

    public void Sound(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        sound = (Sound)scene.buildIndex;

        scenerySource.clip = Resources.Load<AudioClip>(sound.ToString());

        scenerySource.loop = true;
        scenerySource.Play();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
