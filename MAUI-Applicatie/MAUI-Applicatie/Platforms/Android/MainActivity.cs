using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Util;
using Android.Widget;
using Firebase;
using Firebase.Messaging;
using Plugin.Firebase.CloudMessaging;
using Plugin.Firebase.Core.Platforms.Android;

namespace MAUI_Applicatie;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override async void OnCreate(Bundle savedInstanceState)
    {
        
        base.OnCreate(savedInstanceState);
#if ANDROID
        var options = new FirebaseOptions.Builder()
            .SetApplicationId("1:411357933470:android:54af3b2533a751b08f")
            .SetApiKey("AIzaSyB6Vkzd7YG5Rwu1rrk1H4MfiET57Cu-5N4")
            .SetProjectId("maui-applicatie")
            .SetStorageBucket("maui-applicatie.firebasestorage.app")
            .Build();
#endif


        var app = Firebase.FirebaseApp.InitializeApp(this);
        if (app == null)
        {
            app = Firebase.FirebaseApp.InitializeApp(this, options);
        }


        HandleIntent(Intent);
        CreateNotificationChannelIfNeeded();

        var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();
        Android.Util.Log.Debug("FCM", $"FCM Token: {token}");

        CrossFirebaseCloudMessaging.Current.TokenChanged += (sender, args) =>
        {
            Android.Util.Log.Debug("FCM", $"Refreshed token: {args.Token}");
        };

        CrossFirebaseCloudMessaging.Current.NotificationReceived += (sender, args) =>
        {
            var title = args.Notification?.Title ?? "(no title)";
            var body = args.Notification?.Body ?? "(no body)";
            Android.Util.Log.Debug("FCM", $"Message received - Title: {title}, Body: {body}");
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
            CreateNotificationChannel();
        }
    }

    private void CreateNotificationChannel()
    {
        var channelId = $"{PackageName}.general";
        var notificationManager = (NotificationManager)GetSystemService(NotificationService);
        var channel = new NotificationChannel(channelId, "General", NotificationImportance.Default);
        notificationManager.CreateNotificationChannel(channel);
        FirebaseCloudMessagingImplementation.ChannelId = channelId;
    }
}
