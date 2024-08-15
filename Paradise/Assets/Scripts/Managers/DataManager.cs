using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Data
{
    private float positionX;
    private float positionY;
    private float positionZ;

    public float PositionX
    {
        get { return positionX; }
        set { positionX = value; }
    }

    public float PositionY
    {
        get { return positionY; }
        set { positionY = value; }
    }

    public float PositionZ
    {
        get { return positionZ; }
        set { positionZ = value; }
    }

}

public class DataManager : Singleton<DataManager>
{
    [SerializeField] Data data = new Data();

    [SerializeField] string path;
    [SerializeField] string fileName = "Data";

    public void Load()
    {
        data.PositionX = PlayerPrefs.GetFloat("PositionX");
        data.PositionY = PlayerPrefs.GetFloat("PositionY");
        data.PositionZ = PlayerPrefs.GetFloat("PositionZ");
    }

    public void Save()
    {
        PlayerPrefs.Save();
    }

    public void SetTransform(Vector3 direction, Quaternion quaternion)
    {
        data.PositionX = direction.x;
        data.PositionY = direction.y;
        data.PositionZ = direction.z;

        PlayerPrefs.SetFloat("PositionX", data.PositionX);
        PlayerPrefs.SetFloat("PositionY", data.PositionY);
        PlayerPrefs.SetFloat("PositionZ", data.PositionZ);
    }

    public Vector3 GetPosition()
    {
        return new Vector3(data.PositionX, data.PositionY, data.PositionZ);
    }
}
