using System;
namespace simple_benefits_api.Models
{
    public class BenefitsCalcParameters
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Dependent[] Dependents { get; set; }

    }

    public class Dependent
    {
        public string FirstName {get;set;}

        public string LastName { get; set; }

    }
}
