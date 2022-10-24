using System.IO;
using UnityEngine;

[System.Serializable]
public class Data
{
    public int spaceShipCount;
    public int diamond;
}


public class DataManager : MonoBehaviour
{
    public AudioSource fullSound;
    public Data data = new Data();
    public static DataManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        Load();
    }

    private void Start()
    {
        fullSound.Play();
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/GameData.json", json);
    }

    public void Load()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
        data = JsonUtility.FromJson<Data>(jsonData);
    }

}
