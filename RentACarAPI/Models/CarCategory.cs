namespace RentACarAPI
{
    public partial class CarCategory
    {
        public string Bilkategorinamn { get; set; }
        
        public CarCategory(string Bilkategorinamn)
        {
            this.Bilkategorinamn = Bilkategorinamn;
        }
    }
}
