using OfGemCalculatorAPI.Data;
using OfGemCalculatorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfGemCalculatorAPI.Services
{
    public class LogCalculationService : ILogCalculationService
    {
        public bool LogCalculation(LogCalculation logCalculation)
        {
            try
            {
                using (var ctx = new CalculateContext())
                {
                    var logCalc = new LogCalculation()
                    {
                        ClientIp = logCalculation.ClientIp,
                        Calculationdate = logCalculation.Calculationdate
                    };
                    ctx.LogCalculations.Add(logCalc);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}