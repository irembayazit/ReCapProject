using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard : IEntity
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public string CardNumber { get; set; }
        public string CardCvv { get; set; }
        public decimal Money { get; set; }
        public string EndDate { get; set; }
        
    }
}
