using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace SmartHotel360.Specflow
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .DeviceSerial("0038075375")
                    //.DeviceSerial("emulator-5554")
                    .InstalledApp(@"com.microsoft.smarthotel")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}