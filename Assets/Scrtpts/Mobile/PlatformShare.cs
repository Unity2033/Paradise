using System.Collections;
using UnityEngine;

public class PlatformShare : MonoBehaviour
{
    public void Share()
    {
        StartCoroutine(ScreenShotShare());
    }

    private IEnumerator ScreenShotShare()
    {
        yield return new WaitForEndOfFrame();

        Texture2D picture= new Texture2D(Screen.width, Screen.height,TextureFormat.RGB24, false);
        picture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        picture.Apply();

        string filePath = System.IO.Path.Combine(Application.temporaryCachePath, "ScreenShot.png");
        System.IO.File.WriteAllBytes(filePath, picture.EncodeToPNG());

        Destroy(picture);

        new NativeShare { }
            .AddFile(filePath).SetSubject("")
            .SetText("").SetUrl("")
            .SetCallback((result, target) => Debug.Log($"result{result}, target {target}"))
            .Share();
    }
}
