using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Firebase;
using Plugin.Firebase.CloudMessaging;

namespace MAUI_Applicatie
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                               ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Initialize Firebase
            var app = FirebaseApp.InitializeApp(this);
            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetApplicationId("1:411357933470:android:54af3b2533a751b08f")
                    .SetApiKey("AIzaSyB6Vkzd7YG5Rwu1rrk1H4MfiET57Cu-5N4")
                    .SetProjectId("maui-applicatie")
                    .SetStorageBucket("maui-applicatie.firebasestorage.app")
                    .Build();

                app = FirebaseApp.InitializeApp(this, options);
            }

            HandleIntent(Intent);
            CreateNotificationChannelIfNeeded();

            // Request notification permission on Android 13+
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
            {
                if (CheckSelfPermission(Android.Manifest.Permission.PostNotifications) != Permission.Granted)
                {
                    RequestPermissions(new[] { Android.Manifest.Permission.PostNotifications }, 101);
                }
            }

            // Log FCM token
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
            Log.Debug("FCM", $"FCM Token: {token}");

            CrossFirebaseCloudMessaging.Current.TokenChanged += (sender, args) =>
            {
                Log.Debug("FCM", $"Refreshed token: {args.Token}");
            };

            CrossFirebaseCloudMessaging.Current.NotificationReceived += (sender, args) =>
            {
                var title = args.Notification?.Title ?? "(no title)";
                var body = args.Notification?.Body ?? "(no body)";
                Log.Debug("FCM", $"Message received - Title: {title}, Body: {body}");
            };
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            HandleIntent(intent);
        }

        private static void HandleIntent(Intent intent)
        {
            FirebaseCloudMessagingImplementation.OnNewIntent(intent);
        }

        private void CreateNotificationChannelIfNeeded()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                var channelId = $"{PackageName}.general";
                var notificationManager = (NotificationManager)GetSystemService(NotificationService);
                var channel = new NotificationChannel(channelId, "General", NotificationImportance.Default);
                notificationManager.CreateNotificationChannel(channel);
                FirebaseCloudMessagingImplementation.ChannelId = channelId;
            }
        }
    }
}
