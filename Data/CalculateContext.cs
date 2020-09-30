using OfGemCalculatorAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OfGemCalculatorAPI.Data
{
    public class CalculateContext : DbContext 
    {
        public CalculateContext(): base("name=connectionString")
        {

        }
        public DbSet<LogCalculation> LogCalculations { get; set; }
    }
}