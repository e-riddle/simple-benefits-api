using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simple_benefits_api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace simple_benefits_api.Controllers
{
    [Route("api/[controller]")]
    public class BenefitsCalcController : Controller
    {
       /// <summary>
       /// Calculates benefits based on employee and dependents
       /// </summary>
       /// <returns>The calculated value.</returns>
       /// <param name="parameters">Benefits calc parameter object.</param>
        [HttpPost]
        public async Task<decimal> Post([FromBody]BenefitsCalcParameters parameters)
        {
            var calculator = new HealthBenefitsCalculator();

            return await calculator.CalculateHealthCareBenefit(parameters);

        }


    }
}
