using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.Support.V4.App;
using Knowledge_Booster.Droid;
using Firebase.Iid;
using Java.Net;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Dependency(typeof(NotificationHelper))]
namespace Knowledge_Booster.Droid
{
    class NotificationHelper : INotification
    {
        private Context mContext;
        private NotificationManager mNotificationManager;
        private NotificationCompat.Builder mBuilder;
        public static String NOTIFICATION_CHANNEL_ID = "10023";

        public NotificationHelper()
        {
            mContext = global::Android.App.Application.Context;
        }
        public void CreateNotification(String title, String message, IDictionary<string, string> data)
        {
            try
            {
                var intent = new Intent(mContext, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);

                //intent.PutExtra(title, message);

                foreach (var key in data.Keys)
                {
                    intent.PutExtra(key, data[key]);
                }

                if (title == string.Empty)
                    title = data.ContainsKey("title") ? data["title"] : "AppName";

                if (message == string.Empty)
                    message = data.ContainsKey("body") ? data["body"] : "Notification";

                //message = FirebaseInstanceId.Instance.Token;

                var pendingIntent = PendingIntent.GetActivity(mContext, 0, intent, PendingIntentFlags.OneShot);

                var sound = global::Android.Net.Uri.Parse(ContentResolver.SchemeAndroidResource + "://" + mContext.PackageName + "/" + Resource.Raw.notification);
                // Creating an Audio Attribute
                var alarmAttributes = new AudioAttributes.Builder()
                    .SetContentType(AudioContentType.Sonification)
                    .SetUsage(AudioUsageKind.Notification).Build();

                var res = mContext.Resources;
                var largeImageBitmap = BitmapFactory.DecodeResource(res, Resource.Mipmap.logo_icon);


                mBuilder = new NotificationCompat.Builder(mContext);
                mBuilder.SetSmallIcon(Resource.Mipmap.logo_icon);
                mBuilder.SetContentTitle(title)
                        .SetSound(sound)
                        .SetAutoCancel(true)
                        .SetContentTitle(title)
                        .SetContentText(message)
                        .SetChannelId(NOTIFICATION_CHANNEL_ID)
                        .SetPriority((int)NotificationPriority.High)
                        .SetVibrate(new long[0])
                        .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate)
                        .SetVisibility((int)NotificationVisibility.Public)

                        .SetContentIntent(pendingIntent);

                if (data.ContainsKey("ImageUrl"))
                {
                    var urlString = data["ImageUrl"].ToString();
                    var url = new URL(urlString);
                    var connection = (HttpURLConnection)url.OpenConnection();
                    connection.DoInput = true;
                    connection.Connect();
                    var input = connection.InputStream;
                    var bitmap = BitmapFactory.DecodeStream(input);
                    var style = new NotificationCompat.BigPictureStyle()
                            .BigPicture(bitmap)
                            .SetSummaryText(message);
                    connection.Dispose();
                    mBuilder.SetStyle(style).SetLargeIcon(bitmap);

                }


                NotificationManager notificationManager = mContext.GetSystemService(Context.NotificationService) as NotificationManager;

                if (global::Android.OS.Build.VERSION.SdkInt >= global::Android.OS.BuildVersionCodes.O)
                {
                    NotificationImportance importance = global::Android.App.NotificationImportance.High;

                    NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, title, importance);
                    notificationChannel.EnableLights(true);
                    notificationChannel.EnableVibration(true);
                    notificationChannel.SetSound(sound, alarmAttributes);
                    notificationChannel.SetShowBadge(true);
                    notificationChannel.Importance = NotificationImportance.High;
                    notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 });

                    if (notificationManager != null)
                    {
                        mBuilder.SetChannelId(NOTIFICATION_CHANNEL_ID);
                        notificationManager.CreateNotificationChannel(notificationChannel);
                    }
                }

                notificationManager.Notify(0, mBuilder.Build());
            }
            catch (Exception ex)
            {
                //
            }
        }
    }
}