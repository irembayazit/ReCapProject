using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        public int Id { get; set; }
        public int brandId { get; set; }
        public int colorId { get; set; }
        public int modelYear { get; set; }
        public int dailyPrice { get; set; }
        public string description { get; set; }
        public int Findex { get; set; }
    }
}
