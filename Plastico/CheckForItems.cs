using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace Plastico
{
    public class CheckForItems
    {
        public static void DateChecker()
        {
            string FileLocation = @"URI=file:TodoList.db";
            string Date = DateTime.Today.ToShortDateString();
            using var Connections = new SQLiteConnection(FileLocation);
            Connections.Open();
            string SelectedItems = "SELECT Item_Date FROM TodoList";
            using var CommandText = new SQLiteCommand(SelectedItems, Connections);
            using SQLiteDataReader ReadDataBaseInfo = CommandText.ExecuteReader();
            ReadDataBaseInfo.Read();
            if (ReadDataBaseInfo.GetString(0) == Date)
            {
                Task.Run(() => NotificationManager.SendNotif());
            }
        }
    }
}