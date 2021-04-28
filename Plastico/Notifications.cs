using System;
using System.Runtime.InteropServices;
using DesktopNotifications.FreeDesktop;
using DesktopNotifications;
using System.Threading.Tasks;
using DesktopNotifications.Windows;

namespace Plastico
{
    public class NotificationManager
    {
    
        private static INotificationManager CreateManager()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new FreeDesktopNotificationManager();
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new WindowsNotificationManager();
            }
            throw new PlatformNotSupportedException();
        }

        public static async Task SendNotif()
        {
            using var manager = CreateManager();
            await manager.Initialize();

            var notification = new Notification
            {
                Title = "Plastico",
                Body = "You have items due today!",
            };

            await manager.ShowNotification(notification);
            await Task.Delay(10);
        }
    }
}
