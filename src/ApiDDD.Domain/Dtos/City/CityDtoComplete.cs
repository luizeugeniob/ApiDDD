using ApiDDD.Domain.Dtos.State;
using System;

namespace ApiDDD.Domain.Dtos.City
{
    public class CityDtoComplete
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int IBGECode { get; set; }
        public Guid StateId { get; set; }

        public StateDto State { get; set; }
    }
}
