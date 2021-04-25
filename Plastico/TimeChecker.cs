using System;
using System.Threading;

namespace Plastico
{
    public class TimeChecker
    {
        public static void Check()
        {
            var startTimeSpan = TimeSpan.Zero;
            var periodTimeSpan = TimeSpan.FromSeconds(5);
            var timer = new Timer((e) =>
            {
                CheckForItems.DateChecker();   
            }, null, startTimeSpan, periodTimeSpan);
        }
    }
}