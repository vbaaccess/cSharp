using System;
using System.Collections.Generic;
using System.Text;

namespace KlasyAbstrakcyjneIDelegaty
{
    public class Car : Vehicle
    {
        public Car(decimal price, string brand, string model)
        {
            Price = price;
            Brand = brand;
            Model = model;
        }
        public override decimal Price { get; set; }

        public string Brand { get; private set; }
        public string Model { get; private set; }

        public override void RunDiagnostic() => throw new NotImplementedException();
    }
}
