using OfGemCalculatorAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfGemCalculatorAPI.Services
{
    interface ILogCalculationService
    {
        bool LogCalculation(LogCalculation logCalculation);
    }
}
