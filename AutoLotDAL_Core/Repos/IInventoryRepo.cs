using AutoLotDAL_Core.Models;
using System.Collections.Generic;

namespace AutoLotDAL_Core.Repos
{
    public interface IInventoryRepo : IRepo<Inventory>
    {
        List<Inventory> Search(string searchString);
        List<Inventory> GetPinkCars();
        List<Inventory> GetRelatedData();
    }
}
