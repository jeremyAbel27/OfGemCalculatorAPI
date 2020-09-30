using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OfGemCalculatorAPI.Models
{
    public class LogCalculation
    {
        public int Id { get; set; }

        public string ClientIp { get; set; }

        public DateTime Calculationdate { get; set; }
    }
}