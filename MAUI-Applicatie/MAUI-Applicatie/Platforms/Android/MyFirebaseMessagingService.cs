//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Android.App;
//using Firebase.Messaging;

//namespace MAUI_Applicatie.Platforms.Android
//{
//    [Service]
//    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
//    public class MyFirebaseMessagingService : FirebaseMessagingService
//    {
//        public override void OnMessageReceived(RemoteMessage message)
//        {
//            base.OnMessageReceived(message);

//            // Extract notification data and show local notification if needed
//            var notification = message.GetNotification();
//            if (notification != null)
//            {
//                // Show notification with notification.Title and notification.Body
//            }
//        }

//        public override void OnNewToken(string token)
//        {
//            base.OnNewToken(token);
//            System.Diagnostics.Debug.WriteLine($"Firebase token: {token}");
//            // Send this token to your backend or save it
//        }
//    }

//}
