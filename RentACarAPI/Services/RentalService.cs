using RentACarAPI.Data;
using RentACarAPI.Calculations;
using System;
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
            PriceLogic priceLogic = new PriceLogic();
            return priceLogic.CalculatePrice(MyRental, returnRental);
        }
    }
}
