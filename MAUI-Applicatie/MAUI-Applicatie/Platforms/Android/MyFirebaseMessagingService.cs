﻿using Android.App;
using Android.Util;
using Firebase.Messaging;

namespace MAUI_Applicatie.Platforms.Android
{
    [Service(Exported = false)]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "FCM";

        public override void OnNewToken(string token)
        {
            base.OnNewToken(token);
            Log.Debug(TAG, $"New token: {token}");
            // Optional: Send token to your backend if needed
        }

        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            var title = message.GetNotification()?.Title ?? "No title";
            var body = message.GetNotification()?.Body ?? "No body";

            Log.Debug(TAG, $"Message Received - Title: {title}, Body: {body}");
            // Optional: Display local notification here if needed
        }
    }
}
