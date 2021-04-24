using System;
using System.IO;
using CommandLine;
using System.Reflection;


namespace Plastico
{

    class Program
    {
        public interface ICommand
        {
            void Execute();
        }
        
        [Verb("remove", HelpText = "Remove item from the TodoList.")]
        class RemoveOptions : ICommand{
            [Option('i', "item", Required = true, HelpText = "Item to remove from Plastico.")]
            public int Object { get; set; }
            public void Execute()
            {
                Database DB = new Database();
                DB.RemoveItem(Object);
            }
        }

        [Verb("add", HelpText = "Add new item to Plastico.")]
        class AddOptions : ICommand{
            [Option('i', "item", Required = true, HelpText = "Item to add to list.")]
            public string Item { get; set; }
            [Option('d', "date", Required = false, HelpText = "Date to add to list.")]
            public DateTime Date { get; set; }
            
            public void Execute()
            {
                if (Date == default(DateTime))
                {
                    Date = DateTime.Today;
                }
                Database DB = new Database();
                DB.AddToDataBase(Item, Date);
            }
        }
        [Verb("menu", isDefault: true, HelpText = "Shows the Main Menu for Plastico.")]
        class Menu : ICommand{
            public void Execute()
            {
                PlasticoTodoApp TodoApp = new PlasticoTodoApp();
                do
                TodoApp.MenuAction();
                while (true);
            }
        }

        [Verb("print", HelpText = "Prints all the items contained in the Plastico Database.")]
        class Print : ICommand{
            public void Execute()
            {
                Database.ReadDataBase();
            }
        }
            
        static void Main(string[] args)
        {
            if (!File.Exists(@"TodoList.db"))
            {
                Database DB = new Database();
                DB.CreateDataBase();
                Console.WriteLine("Made file at " + "TodoList.db");
            }
            else
            {
                Assembly assembly = Assembly.LoadFrom("NotifManager.dll");
                object mc = assembly.CreateInstance("Plastico.NotifySend");
                Type t = mc.GetType();
                BindingFlags bf = BindingFlags.Instance | BindingFlags.NonPublic;
                MethodInfo mi = t.GetMethod("SendNotification", bf);
                mi.Invoke(mc, null);
                Database DB = new Database();
                Parser.Default.ParseArguments<Menu, RemoveOptions, AddOptions, Print>(args).WithParsed<ICommand>(t => t.Execute());
            }
        }
    }        
}
