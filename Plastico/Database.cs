using System;
using System.Data.SQLite;


namespace Plastico
{
    public class Database
    {
    private string FileLocation = @"URI=file:TodoList.db";
        public void CreateDataBase()
        {
            using var Connections = new SQLiteConnection(FileLocation);
            Connections.Open();
            using var Command = new SQLiteCommand(Connections);
            Command.CommandText = @"DROP TABLE IF EXISTS TodoList";
            Command.ExecuteNonQuery();
            Command.CommandText = @"CREATE TABLE TodoList(Item_Details TEXT, Item_Date TEXT)";
            Command.ExecuteNonQuery();
        }
        public static void ReadDataBase()
        {
            string FileLocation = @"URI=file:TodoList.db";
            using var Connections = new SQLiteConnection(FileLocation);
            Connections.Open();
            string SelectedItems = "SELECT rowid, * FROM TodoList ORDER BY ROWID ASC LIMIT 10";
            using var CommandText = new SQLiteCommand(SelectedItems, Connections);
            using SQLiteDataReader ReadDataBaseInfo = CommandText.ExecuteReader();
            Console.WriteLine("Your TodoList:");
            while (ReadDataBaseInfo.Read())
            {

                Console.WriteLine($"[{ReadDataBaseInfo.GetInt32(0)}] {ReadDataBaseInfo.GetString(1)} {ReadDataBaseInfo.GetString(2)}");
            }

        }
        public void AddToDataBase(string NewItem, DateTime Date)
        {
            using var Connections = new SQLiteConnection(FileLocation);
            Connections.Open();
            var SQL = "INSERT INTO TodoList(Item_Details, Item_Date) VALUES(@Item_Details, @Item_Date)";
            using var InsertSQL = new SQLiteCommand(SQL, Connections);
            try
            {
                InsertSQL.Parameters.AddWithValue("@Item_Details", NewItem);
                InsertSQL.Parameters.AddWithValue("@Item_Date", Date.ToShortDateString());
                InsertSQL.ExecuteNonQuery();
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"{e.GetType().Name}: Please insert the required amount of items into the list.");
            }
            catch (FormatException e)
            {
                Console.WriteLine($"{e.GetType().Name}: Please insert a number into the list");
            }
            finally
            {
                Console.WriteLine($"Added new items to the list.");
                Connections.Close();
            }
        }
        public void RemoveItem(int RemoveItemNumber)
        {
            
            using var Connections = new SQLiteConnection(FileLocation);
            Connections.Open();
            var SQL = "DELETE FROM TodoList WHERE ROWID=@Item_Number";
            using var RemoveSQL = new SQLiteCommand(SQL, Connections);
            RemoveSQL.Parameters.AddWithValue("@Item_Number", RemoveItemNumber);
            RemoveSQL.ExecuteNonQuery();
            var Clean = "VACUUM";
            using var CleanSQL = new SQLiteCommand(Clean, Connections);
            CleanSQL.ExecuteNonQuery();
            Console.WriteLine($"Removed Item {RemoveItemNumber} from the list.");
        }
}
}
