using System;
using System.Threading.Tasks;

namespace RentACarAPI.Data
{
    // kompletta objekt redo att tilläggas i data lagring.
    public class Repository
    {
        public async Task<Rental> RegisterRental(Rental rental)
        {
            try
            {
                return rental;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ReturnRental> RegisterReturnRental(ReturnRental returnRental)
        {
            try
            {
                return returnRental;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
