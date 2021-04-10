using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Utilities.Results.Concrate;
using Business.Constent;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [ValidationAspect(typeof(CreditCardValidator))]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);

            return new SuccessResult(Messages.CreditCardAdded);
        }

        public IDataResult<List<CreditCard>> CardControl(int customerId)
        {
            var result = _creditCardDal.GetAll(p => p.CustomerId == customerId);
            if(result != null)
            {
                return new SuccessDataResult<List<CreditCard>>(result, Messages.CreditCardControl);
            }
            return new ErrorDataResult<List<CreditCard>>(Messages.CreditCardControlNot);
        }

        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
