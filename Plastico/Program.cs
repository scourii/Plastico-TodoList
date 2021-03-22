using System;
using System.IO;

namespace Plastico
{

    class Program
    {
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
                Console.WriteLine("Using TodoList.db");
                PlasticoTodoApp TodoApp = new PlasticoTodoApp();
                do
                TodoApp.MenuAction();
                while (true);
                    }
                }
        }
    }
