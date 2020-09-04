using System;

namespace ApiDDD.Domain.Dtos.City
{
    public class CityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IBGECode { get; set; }
        public Guid StateId { get; set; }
    }
}
