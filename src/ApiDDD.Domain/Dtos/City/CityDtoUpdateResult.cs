using System;

namespace ApiDDD.Domain.Dtos.City
{
    public class CityDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IBGECode { get; set; }
        public Guid StateId { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
