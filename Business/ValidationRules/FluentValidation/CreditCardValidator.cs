using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CreditCardValidator : AbstractValidator<CreditCard>
    {
        public CreditCardValidator()
        {
            RuleFor(p => p.CardNumber).Length(16);
            RuleFor(p => p.CardCvv).Length(3);
            RuleFor(p => p.CardNumber).NotEmpty();
            RuleFor(p => p.CardCvv).NotEmpty();
            RuleFor(p => p.EndDateMonth).NotEmpty();
            RuleFor(p => p.EndDateYear).NotEmpty();
            RuleFor(p => p.NameSurname).NotEmpty();
        }
    }
}
