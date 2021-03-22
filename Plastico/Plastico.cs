using System;
using System.IO;
using System.Collections;
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
                    Console.WriteLine("Add the new item in the format: '1 Details yyyy-MM-dd HH:mm");
                    string NewItem = Console.ReadLine();
                    DB.AddToDataBase(NewItem);
                    break;
                case Operations.RemoveItems:
                    Console.WriteLine("Insert the number of the item you wish to remove:");
                    int ItemToRemove = Int32.Parse(Console.ReadLine());
                    DB.RemoveItem(ItemToRemove);
                    break;
                case Operations.PrintItems:
                    Database.ReadDataBase();
                    break;
                case Operations.Exit:
                    Environment.Exit(0);
                    break;

            }
    }
    }
    }
