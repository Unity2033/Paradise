using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMode : MonoBehaviour
{
    public Canvas myCanvas;

    private void Start()
    {
        myCanvas = GetComponent<Canvas>();

        myCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
    }
}
