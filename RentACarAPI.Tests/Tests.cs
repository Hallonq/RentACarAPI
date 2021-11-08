using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using RentACarAPI.Calculations;
using System;
using Assert = NUnit.Framework.Assert;

namespace RentACarAPI.Tests
{
    [TestClass]
    public class Tests
    {
        [Test]
        public void Småbil_TestCalculatePrice()
        {
            //ARRANGE
            var priceLogic = new PriceLogic();
            var rental = new Rental()
            {
                Datum = DateTime.UtcNow.Date,
                Bilkategori = new CarCategory("småbil")
            };

            var rentalReturn = new ReturnRental()
            {
                Datum = DateTime.UtcNow.Date
            };

            var basDygnsHyra = 500;

            //ACT
            var result = priceLogic.CalculatePrice(rental, rentalReturn);

            //ASSERT
            var expected = (rentalReturn.Datum - rental.Datum).TotalDays * basDygnsHyra;
            Assert.That(result == expected);
        }

        [Test]
        public void Kombi_TestCalculatePrice()
        {
            //ARRANGE
            var priceLogic = new PriceLogic();
            var rental = new Rental()
            {
                Datum = DateTime.UtcNow.Date,
                Bilkategori = new CarCategory("kombi"),
                Matarinstallning = 100
            };
            var rentalReturn = new ReturnRental()
            {
                Datum = DateTime.UtcNow.Date,
                Matarinstallning = 100
            };

            var basDygnsHyra = 1000;
            var basKmPris = 10;

            //ACT
            var result = priceLogic.CalculatePrice(rental, rentalReturn);

            //ASSERT
            var expected = (rentalReturn.Datum - rental.Datum).TotalDays * basDygnsHyra * 1.3 + basKmPris * (rentalReturn.Matarinstallning - rental.Matarinstallning);
            Assert.That(result == expected);
        }

        [Test]
        public void LastBil_TestCalculatePrice()
        {
            //ARRANGE
            var priceLogic = new PriceLogic();
            var rental = new Rental()
            {
                Datum = DateTime.UtcNow.Date,
                Bilkategori = new CarCategory("lastbil"),
                Matarinstallning = 100
            };
            var rentalReturn = new ReturnRental()
            {
                Datum = DateTime.UtcNow.Date,
                Matarinstallning = 100
            };

            //ACT
            var basDygnsHyra = 1500;
            var basKmPris = 15;
            var result = priceLogic.CalculatePrice(rental, rentalReturn);

            //ASSERT
            var expected = (rentalReturn.Datum - rental.Datum).TotalDays * basDygnsHyra * 1.5 + basKmPris * (rentalReturn.Matarinstallning - rental.Matarinstallning) * 1.5;
            Assert.That(result == expected);
        }

        [Test]
        public void InvalidCategory_TestCalculatePrice()
        {
            //ARRANGE
            var priceLogic = new PriceLogic();
            var rental = new Rental()
            {
                Bilkategori = new CarCategory("invalid")
            };
            var rentalReturn = new ReturnRental();

            //ASSERT
            Assert.That(() => priceLogic.CalculatePrice(rental, rentalReturn), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
