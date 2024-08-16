using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] protected bool isOpen = false;

    protected float openTime;

    public virtual void OnClick(Collider collider) { }

}