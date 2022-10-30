using UnityEngine;
using Unity.Notifications.Android;

public class Notification : MonoBehaviour
{
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();

        var channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Notifications_Chanel_Name",
            Importance = Importance.Default,
            Description = "Generic notification",
        };

        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification();
        notification.Title = "Come Back Meow Meow";
        notification.Text = "Go Go Play Space Cat's~";
        notification.FireTime = System.DateTime.Now.AddHours(1);

        var ID = AndroidNotificationCenter.SendNotification(notification, "channel_id");

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(ID) == NotificationStatus.Scheduled)
        {
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }

    }
}
