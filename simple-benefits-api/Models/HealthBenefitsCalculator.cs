﻿using System;
using System.Threading.Tasks;

namespace simple_benefits_api.Models
{

    //TODO: This class should be stored in different project since is not API specific; Keeping it in API project for now for simplicity
    public class HealthBenefitsCalculator
    {
        protected readonly int payPeriods;
        protected readonly decimal employeeBaseCost;
        protected readonly decimal dependentBaseCost;
        protected readonly decimal discountRate;

        public HealthBenefitsCalculator()
        {
            //TODO: pull this from configuration; never hardcode
            //TODO: Determine payperiods based on pay cycle (weekly, biweekly, semimonthly, and monthly)
            this.payPeriods = 26; 
            this.employeeBaseCost = (decimal)1000;
            this.dependentBaseCost = (decimal)500;
            this.discountRate = (decimal)0.1;

        }

        public async Task<decimal> CalculateHealthCareBenefit (BenefitsCalcParameters parameters)
        {
            decimal total = 0;

            total += await this.CalcDependentCost(parameters.FirstName, this.employeeBaseCost);

            if (parameters.Dependents != null)
            {
                foreach (var dependent in parameters.Dependents)
                {
                    total += await this.CalcDependentCost(dependent.FirstName, this.dependentBaseCost);
                }
            }

            return total;
        }

        private async Task<decimal> CalcDependentCost(string firstName, decimal baseCost)
        {
            if (firstName.ToLower().StartsWith('a'))
            {
                return await Task.FromResult<decimal>((1 - this.discountRate) * baseCost);
            }
            else
            {
                return await Task.FromResult<decimal>(baseCost);
            }
        }
    }
}
