using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiDDD.Domain.Entities
{
    public class CityEntity : BaseEntity
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        public int IBGECode { get; set; }
        [Required]
        public Guid StateId { get; set; }

        public StateEntity State { get; set; }
        public IEnumerable<AddressEntity> Addresses { get; set; }
    }
}
