using UnityEngine;
using UnityEngine.UI;

public class GroundScroll : MonoBehaviour
{
    private Rect rect;
    private RawImage scenery;

    void Start()
    {
        scenery = GetComponent<RawImage>();
    }

    public void VerticalScroll(float speed)
    {
        rect = scenery.uvRect;

        rect.y += Time.deltaTime * speed;

        scenery.uvRect = rect;
    }

    private void Update()
    {
        VerticalScroll(0.1f);
    }
}
