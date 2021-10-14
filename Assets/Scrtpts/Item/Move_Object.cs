using UnityEngine;

public class Move_Object : MonoBehaviour
{
    BH_GameManager Game;
    public Vector3 dir = Vector3.zero;

    public float _speed;

    void Start()
    {
        dir.Normalize();
        Game = GameObject.Find("GameManager").GetComponent<BH_GameManager>();
    }

    public void Direction_Item(Vector3 direction)
    {
        dir = direction;
    }

    public void Set_Item(float speed)
    {
        _speed = speed;
    }

}
