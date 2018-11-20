using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;


namespace AutoLotDAL_Core.EF
{
    public class AutoLotContext : DbContext
    {
        public AutoLotContext(DbContextOptions options) : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"server=IDEA-PC\MSSQLSERVER01;database=AutoLotCore2;integrated security=true;MultipleActiveResultSets=True;App=EntityFramework;";
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure())
                       .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
            }
        }

        internal AutoLotContext() { }

        public DbSet<AutoLotDAL_Core.Models.CreditRisk> CreditRisks { get; set; }
        public DbSet<AutoLotDAL_Core.Models.Customer> Customers { get; set; }
        public DbSet<AutoLotDAL_Core.Models.Inventory> Cars { get; set; }
        public DbSet<AutoLotDAL_Core.Models.Order> Orders { get; set; }

        public string GetTableName(Type type)
        {
            return Model.FindEntityType(type).SqlServer().TableName;
        } 
    }
}
