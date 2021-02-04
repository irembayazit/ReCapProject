using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager cars = new CarManager(new InMemoryCarDal());
            foreach (var car in cars.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
