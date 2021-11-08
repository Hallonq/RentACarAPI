using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RentACarAPI
{
    public partial class ReturnRental
    {
        public Guid Bokningsnummer { get; set; }
        public DateTime Datum { get; set; }
        public int Matarinstallning { get; set; }
    }
}
