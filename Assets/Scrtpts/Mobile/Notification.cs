using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System;
using Assets.SimpleAndroidNotifications;

public class Notification : MonoBehaviour
{
    readonly string title = "Space Cat's ";
    readonly string content = "Let's escape the planet~";

    private void OnApplicationPause(bool isPause)
    {
#if UNITY_ANDROID
        // 등록된 알림 모두 제거
        NotificationManager.CancelAll();

        if (isPause)
        {
            // Application 나갔을 때 지정된 시간에 알림이 호출
            DateTime specifiedTime = Convert.ToDateTime("8:00:00 PM");
            TimeSpan timespan = specifiedTime - DateTime.Now;

            if (timespan.Ticks > 0)
            {
                NotificationManager.SendWithAppIcon(timespan, title, content, Color.red, NotificationIcon.Message);
            }               
        }
#endif
    }
}
