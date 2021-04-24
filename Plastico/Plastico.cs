using System;
using System.Collections.Generic;

namespace Plastico
{
    class PlasticoTodoApp
    {   
        Database DB = new Database();
        private List<string> Menu = new List<string>(){
        "        Plastico",
        "------------------------",
        "[1] Add Items",
        "[2] Remove Items",
        "[3] Print List",
        "[4] Exit",
        };
        
        public void MenuAction()
        {
            for (int i = 0; i < Menu.Count; i++)
            {
                Console.WriteLine(Menu[i]);
            }
            int EnumChoice;
            EnumChoice = Int32.Parse(Console.ReadLine());
            MainMenu((Operations)EnumChoice);
            
        }
        private void MainMenu(Operations Choice)
        { 
            switch(Choice)
            {
                case Operations.AddItems:
                    Console.WriteLine("\nAdd a new item to the list:");
                    string NewItem = Console.ReadLine();
                    Console.WriteLine("\nEnter the date.");
                    DateTime Date = DateTime.Parse(Console.ReadLine());
                    DB.AddToDataBase(NewItem, Date);
                    Console.WriteLine($"Added new items to the list.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case Operations.RemoveItems:
                    Console.WriteLine("\nInsert the number of the item you wish to remove:");
                    int ItemToRemove = Int32.Parse(Console.ReadLine());
                    DB.RemoveItem(ItemToRemove);
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case Operations.PrintItems:
                    Database.ReadDataBase();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case Operations.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
