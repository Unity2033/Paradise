using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    private Rect rect;
    private RawImage scenery;
    [SerializeField] float speed = 0.1f;

    void Start()
    {
        scenery = GetComponent<RawImage>();
    }

    private void Update()
    {
        rect = scenery.uvRect;

        rect.y += Time.deltaTime * speed;

        scenery.uvRect = rect;
    }
}
