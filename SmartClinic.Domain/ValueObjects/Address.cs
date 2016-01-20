using System;
using SmartClinic.Domain.Enums;

namespace SmartClinic.Domain.ValueObjects
{
    public class Address
    {
        #region Constructor

        public Address()
        {
        }

        public Address(string publicPlace, string complement, string number, string neighborhood, string city, Uf uf)
        {
            PublicPlace = publicPlace;
            Complement = complement;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            Uf = uf;
        }

        #endregion

        #region Properties

        public string PublicPlace { get; private set; }
        public string Complement { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public Uf Uf { get; set; }

        #endregion

        #region Constants

        public const int PublicPlaceMaxLength = 100;
        public const int ComplementMaxLength = 150;
        public const int NumberMaxLength = 10;
        public const int NeighborhoodMaxLength = 100;
        public const int CityMaxLength = 80;

        #endregion

        #region Methods

        public string GetFullAddress()
        {
            return string.Format("{0}, {1}, {2}, {3}, {4}, {5}", PublicPlace, Number, Complement, Neighborhood, City, Uf.ToString());
        }

        public void SetPublicPlace(string publicPlace)
        {
            if(publicPlace.Length > PublicPlaceMaxLength)
                throw new InvalidOperationException(string.Format("Rua/Logradouro deve possuir no máximo {0} caracteres", PublicPlaceMaxLength));

            PublicPlace = publicPlace;
        }

        public void SetComplement(string complement)
        {
            if(complement.Length > ComplementMaxLength)
                throw new InvalidOperationException(string.Format("Complemento deve possuir no máximo {0} caracteres", ComplementMaxLength));

            Complement = complement;
        }

        public void SetNumber(string number)
        {
            if(number.Length > NumberMaxLength)
                throw new InvalidOperationException(string.Format("Número deve possuir no máximo {0} caracteres", NumberMaxLength));

            int numeric;
            if(!Int32.TryParse(number, out numeric))
                throw new InvalidOperationException("O Numero do endereço deve ser um valor numérico");

            Number = number;
        }

        public void SetNeighborhood(string neighborhood)
        {
            if(neighborhood.Length > NeighborhoodMaxLength)
                throw new InvalidOperationException(string.Format("Bairro deve possuir no máximo {0} caracteres", NeighborhoodMaxLength));

            Neighborhood = neighborhood;
        }

        public void SetCity(string city)
        {
            if(city.Length > CityMaxLength)
                throw new InvalidOperationException(string.Format("Cidade deve possuir no máximo {0} caracteres", CityMaxLength));

            City = city;
        }

        #endregion
    }
}