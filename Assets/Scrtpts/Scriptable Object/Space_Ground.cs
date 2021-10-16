using UnityEngine;

[System.Serializable,CreateAssetMenu(fileName = "Space Skin",menuName = "Create New Space")]
public class Space_Ground : ScriptableObject
{
    public enum Space_Ground_Name { Kepler_452b, Gliese_876, Earth }
    public Space_Ground_Name space_name;

    public Sprite Space_sprite;
    public Material Galaxy;
    public int Price;
}
