using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDDD.Domain.Entities
{
    public class AddressEntity : BaseEntity
    {
        [Required]
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(60)]
        public string Street { get; set; }
        [MaxLength(10)]
        public string Number { get; set; }
        [Required]
        public Guid CityId { get; set; }

        public CityEntity City { get; set; }
    }
}
