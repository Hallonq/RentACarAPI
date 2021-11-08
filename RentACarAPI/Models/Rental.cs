using System;

namespace RentACarAPI
{
    public partial class Rental
    {
        public Guid Bokningsnummer { get; set; }
        public string Registreringsnummer { get; set; }
        public string Personnummer { get; set; }
        public CarCategory Bilkategori { get; set; }
        public DateTime Datum { get; set; }
        public int Matarinstallning { get; set; }
    }
}
