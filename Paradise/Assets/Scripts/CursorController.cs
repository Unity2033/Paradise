using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] GameObject defalutCursor;
    [SerializeField] GameObject interactiveCursor;

    public void SelectCursor(bool defaultCursor, bool interactiveCursor = false)
    {
        this.defalutCursor.SetActive(defaultCursor);
        this.interactiveCursor.SetActive(interactiveCursor);
    }
}
