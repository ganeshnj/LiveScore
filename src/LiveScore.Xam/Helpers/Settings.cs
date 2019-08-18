using System;
using Xamarin.Essentials;

namespace LiveScore.Xam.Helpers
{
    public static class Settings
    {
#if DEBUG
        static readonly string defaultIP = DeviceInfo.Platform == DevicePlatform.Android ? "10.0.2.2" : "localhost";
        static bool defaultHttps = false;
#else
        static readonly string defaultIP = "Replace with production server";
        static bool defaultHttps = true;
#endif

        public static string ServerIP
        {
            get => Preferences.Get(nameof(ServerIP), defaultIP);
            set => Preferences.Set(nameof(ServerIP), value);
        }

        public static string ApiServer
        {
#if DEBUG
            get => $"{ServerIP}:5001/api";
#else
            get => $"{ServerIP}/api";
#endif
        }

        public static bool UseHttps
        {
            get => Preferences.Get(nameof(UseHttps), defaultHttps);
            set => Preferences.Set(nameof(UseHttps), value);
        }
    }
}
