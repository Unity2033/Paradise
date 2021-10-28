using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class Notification_Manager : MonoBehaviour
{
    void Start()
    {
        // 이미 표시된 알림 제거
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        // 다음을 통해 메시지를 보낼 안드로이드 알림 채널 생성
        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications_Chanel_Name",
            Importance = Importance.Default,
            Description = "Generic notification",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        // 발송할 통지 작성
        var notification = new AndroidNotification();
        notification.Title = "Come Back Meow Meow";
        notification.Text = "Go Go Play Space Cat's~";
        notification.FireTime = System.DateTime.Now.AddHours(1);

        // 알림을 보낸다.
        var ID = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        // 스크립트가 실행되고 메시지가 이미 예약된 경우, 스크립트를 취소하고 다른 메시지를 다시 수신합니다.
        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(ID) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }

    }
}
