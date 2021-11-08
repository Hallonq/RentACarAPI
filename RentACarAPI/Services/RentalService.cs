using RentACarAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentACarAPI.Services
{
    public class RentalService
    {
        public static Rental MyRental;
        private readonly Repository _repo;
        public RentalService(Repository repo)
        {
            _repo = repo;
        }

        public async Task<Rental> RegisterRental(Rental rental)
        {
            MyRental = rental;
            return await _repo.RegisterRental(rental);
        }

        public async Task<double> RegisterReturnRental(ReturnRental returnRental)
        {
            // lägger till antal dygn för mer dynamisk priskalkulering.
            Random random = new Random();
            returnRental.Datum = MyRental.Datum.AddDays(random.Next(1, 10));
            // registrera återlämning objekt.
            await _repo.RegisterReturnRental(returnRental);
            // räknar ut pris för hyrning.
            return CalculatePrice(MyRental, returnRental);
        }

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
