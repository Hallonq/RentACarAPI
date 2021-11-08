using RentACarAPI.Services;
using System;

namespace RentACarAPI.Calculations
{
    public class PriceLogic
    {
        public double CalculatePrice(Rental rental, ReturnRental returnRental)
        {
            switch (rental.Bilkategori.Bilkategorinamn.ToLower())
            {
                case "småbil":
                    return
             500 *
             (returnRental.Datum - rental.Datum).TotalDays;

                case "kombi":
                    return
              (1000 *
              (returnRental.Datum - rental.Datum).TotalDays *
              1.3) +
              (10 * returnRental.Matarinstallning);

                case "lastbil":
                    return
            (1500 *
            (returnRental.Datum - rental.Datum).TotalDays *
            1.5) +
            (15 *
            returnRental.Matarinstallning *
            1.5);

                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}
