using System;
using simple_benefits_api.Models;
using Xunit;

namespace simple_benefits_api_tests
{
    public class BenefitsCalculationTests
    {
        

        [Fact]
        public async void TestSingleEmployee()
        {
            var calculator = new HealthBenefitsCalculator();

            var parameters = new BenefitsCalcParameters()
            {
                FirstName = "b",
                LastName = "c"
            };

            var result = await calculator.CalculateHealthCareBenefit(parameters);

            Assert.Equal(1000, result);

        }

        [Fact]
        public async void TestDiscountSingleEmployee()
        {
            var calculator = new HealthBenefitsCalculator();

            var parameters = new BenefitsCalcParameters()
            {
                FirstName = "a",
                LastName = "c"
            };

            var result = await calculator.CalculateHealthCareBenefit(parameters);


            Assert.Equal(900, result);

        }

        [Fact]
        public async void TestSingleEmployeeAndTwoDependent()
        {
            var calculator = new HealthBenefitsCalculator();

            var parameters = new BenefitsCalcParameters()
            {
                FirstName = "b",
                LastName = "c",
                Dependents = new Dependent[]
                {
                    new Dependent(){
                                    FirstName = "c",
                                    LastName = "d"
                                    },
                    new Dependent(){
                                    FirstName = "e",
                                    LastName = "f"
                                    },
                }
            };

            var result = await calculator.CalculateHealthCareBenefit(parameters);

            Assert.Equal(2000, result);

        }

        [Fact]
        public async void TestSingleEmployeeAndTwoDependentOneDiscount()
        {
            var calculator = new HealthBenefitsCalculator();

            var parameters = new BenefitsCalcParameters()
            {
                FirstName = "b",
                LastName = "c",
                Dependents = new Dependent[]
                {
                    new Dependent(){
                                    FirstName = "c",
                                    LastName = "d"
                                    },
                    new Dependent(){
                                    FirstName = "ann",
                                    LastName = "f"
                                    },
                }
            };

            var result = await calculator.CalculateHealthCareBenefit(parameters);

            Assert.Equal(1950, result);

        }
    }
}
