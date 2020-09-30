using Microsoft.AspNetCore.Mvc;
using OfGemCalculatorAPI.Models;
using OfGemCalculatorAPI.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
//using System.Web.Mvc;

namespace OfGemCalculatorAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get([FromBody] string value)
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        // GET api/values/Calculate?values=8x8

        [Route("api/calculate")]
        [HttpGet]
        public Result Calculate(string values)
        {
            var result = new Result();
            result.Input = values.Replace(" ", "+");
            try
            {
                var loDataTable = new DataTable();
                var loDataColumn = new DataColumn("Eval", typeof(double), result.Input);
                loDataTable.Columns.Add(loDataColumn);
                loDataTable.Rows.Add(0);
                result.Output = ((double)(loDataTable.Rows[0]["Eval"])).ToString();
            }
            catch(Exception ex)
            {
                result.Error = "Error with input";
            }


            var logCalculation = new LogCalculation()
            {
                ClientIp = GetIPAddress(),
                Calculationdate = DateTime.Now
            };

            var logCalculationService = new LogCalculationService();


            if (!logCalculationService.LogCalculation(logCalculation))
            {
                result.Error += "- error saving log";
            }

            return result;
        }

        protected string GetIPAddress()
        {
            HttpContext context = HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}
