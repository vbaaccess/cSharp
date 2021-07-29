using System;
using System.Collections.Generic;
using cs = System.Console;
using System.Text;
using System.Linq;

namespace KlasyAbstrakcyjneIDelegaty
{
    static class Helper
    {
        public static void ShowCarsAndSpeed(List<Car> cars)
        {
            cs.WriteLine(
                string.Join(
                        ", "
                      , cars.Select(
                                     c => $"{c.Brand}(speed: {c.Speed})"
                                    )
                    )
                );

        }
        public static void ShowSpeed(Car car)
        {
            // metoda wyswietla konkretny komunikat tylko dla obiektu klasy Car
            cs.WriteLine(
                        $"{car.Brand}(speed: {car.Speed})"
                );

        }

        // przeciazamy metode na potrzeby uzycia delegaty
        public static void ShowSpeed(Vehicle vehicle)       //Krok 5 - tam metod musi byc zgodna z delegata ktora bedzie ja wykorzystywaco (czyli ta z KROKU 1)
        {                                                   //         zgodna co do zwracanego parametrow /void/ oraz przekazywanych parametrow  /Vehicle vehicle/
            // metoda wyswietla komunikat dla dowolnej maszyny (obiektu klasy abstrakcyjnej Vehicle)
            // na ta chwile implementujemy tylko dla obiektow klasy Car
            if (vehicle is Car)
            {
                // Przyklad 1 rzutowania
                //cs.WriteLine(
                //            $"{((Car)vehicle).Brand}(speed: {((Car)vehicle).Speed})"
                //    );

                // Przyklad 2 rzutowania
                // prostszy bo nie trzeba zmieniac kodu ktory byl przerabiony (z metody ShowSpeed(Car car)
                var car = vehicle as Car;
                cs.WriteLine(
                            $"{car.Brand}(speed: {car.Speed})"
                    );
            }
            else
                throw new NotImplementedException(); // dla pozostalych piszemy ze jest brak implementacji
        }
    }
}
