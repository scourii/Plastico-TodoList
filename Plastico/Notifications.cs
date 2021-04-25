using DesktopNotifications.FreeDesktop;
using DesktopNotifications;
using System.Threading.Tasks;

namespace Plastico
{
    public class NotificationManager
    {
    
        private static INotificationManager CreateManager()
        {
            return new FreeDesktopNotificationManager();
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

            await Task.Delay(5);
        }

    }
}