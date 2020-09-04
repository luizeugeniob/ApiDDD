using System;

namespace ApiDDD.Domain.Dtos.State
{
    public class StateDto
    {
        public Guid Id { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
    }
}
