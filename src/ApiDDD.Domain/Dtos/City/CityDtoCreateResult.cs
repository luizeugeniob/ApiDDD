using System;

namespace ApiDDD.Domain.Dtos.City
{
    public class CityDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IBGECode { get; set; }
        public Guid StateId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
