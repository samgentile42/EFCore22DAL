using System.Collections.Generic;
using System.Linq;
using AutoLotDAL_Core.EF;
using AutoLotDAL_Core.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.EF;

namespace AutoLotDAL_Core.Repos
{
    public class InventoryRepo : BaseRepo<Inventory>, IInventoryRepo
    {
        public InventoryRepo(AutoLotContext context) : base(context)
        {
        }

        //public override List<Inventory> GetAll()
        //    => GetAll(x => x.PetName, true).ToList();


        public List<Inventory> GetAllInventory() => GetAll(x => x.PetName, true).ToList();
        public List<Inventory> Search(string searchString)
            => Context.Cars.Where(c => Functions.Like(c.PetName, $"%{searchString}%")).ToList();

        public List<Inventory> GetPinkCars()
            => GetSome(x => x.Color == "Pink");

        public List<Inventory> GetRelatedData()
            => Context.Cars.FromSql("SELECT * FROM Inventory").Include(x => x.Orders).ThenInclude(x => x.Customer).ToList();
    }
}
