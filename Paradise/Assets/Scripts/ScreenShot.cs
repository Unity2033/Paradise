#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class ScreenShot
{

    [MenuItem("ScreenShot/Take Screenshot %&s")]
    public static void TakeScreenshot()
    {
        string path = Application.persistentDataPath + "/" + System.DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".png";
        ScreenCapture.CaptureScreenshot(path);
        Debug.Log("Save Screenshot Capture : " + path);
    }

    [MenuItem("ScreenShot/Open Screenshot Folder %&o")]
    static void OpenScreenshotFolder()
    {
        string path = Application.persistentDataPath;
        Application.OpenURL("file://" + path);
    }

}
#endif