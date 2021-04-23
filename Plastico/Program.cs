using System;
using System.IO;
using CommandLine;
using System.Collections.Generic;

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
            [Option('o', "object", Required = true, HelpText = "Item to add to list.")]
            public int Object { get; set; }
            public void Execute()
            {
                Database DB = new Database();
                DB.RemoveItem(Object);
                Console.WriteLine($"Removed {Object} from the list.");
            }
        }

        [Verb("add", HelpText = "Add new item to Plastico.")]
        class AddOptions : ICommand{
            [Option('o', "object", Required = true, HelpText = "Item to add to list.")]
            public string Object { get; set; }
            public void Execute()
            {
                Database DB = new Database();
                DB.AddToDataBase(Object);
                Console.WriteLine($"Added {Object} to the todolist.");
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
                Database DB = new Database();
                Parser.Default.ParseArguments<Menu, RemoveOptions, AddOptions, Print>(args).WithParsed<ICommand>(t => t.Execute());
            }
        }
    }        
}
