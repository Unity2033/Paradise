using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName ="Shuttle Skin", menuName = "Create New Shuttle")]
public class Space_Ship : ScriptableObject
{
    public enum Shuttle_Name { Atlantis, Discovery, Endeavour }
    public Shuttle_Name shuttle_name;

    public Sprite Shuttle_Sprite;

    public int Price;

}
