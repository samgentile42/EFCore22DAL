using AutoLotDAL_Core.DataInitialization;
using AutoLotDAL_Core.EF;
using AutoLotDAL_Core.Models;
using AutoLotDAL_Core.Repos;
using System;

namespace AutoLotDAL_Core.TestDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************** EF Core 2.2 ****************************");
            using (var context = new AutoLotContext())
            {
                MyDataInitializer.RecreateDatabase(context);
                MyDataInitializer.InitializeData(context);
                foreach(Inventory c in context.Cars)
                {
                    Console.WriteLine(c);
                }
            }

            Console.WriteLine("*************** Using a Repository ****************");
            using (var repo = new InventoryRepo(new AutoLotContext()))
            {
                foreach (Inventory c in repo.GetAllInventory())
                {
                    Console.WriteLine(c);
                }
            }
            Console.ReadLine();
        }
    }
}
