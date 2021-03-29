using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            
            RuleFor(p => p.brandId).NotEmpty();
            RuleFor(p => p.colorId).NotEmpty();
            RuleFor(p => p.dailyPrice).GreaterThan(0);
        }
    }
}
