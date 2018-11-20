using AutoLotDAL_Core.Models.MetaData;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoLotDAL_Core.Models
{
    [ModelMetadataType(typeof(InventoryMetaData))]
    public partial class Inventory
    {
        public override string ToString()
        {
            return $"{this.PetName ?? "**No Name**"} is a {this.Color} {this.Make} wih ID {this.Id}.";

        }
        [NotMapped]
        public string MakeColor => $"{Make} + ({Color })";
    }
}
