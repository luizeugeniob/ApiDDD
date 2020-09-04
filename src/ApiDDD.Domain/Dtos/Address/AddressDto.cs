using ApiDDD.Domain.Dtos.City;
using System;

namespace ApiDDD.Domain.Dtos.Address
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public Guid CityId { get; set; }

        public CityDtoComplete City { get; set; }
    }
}
