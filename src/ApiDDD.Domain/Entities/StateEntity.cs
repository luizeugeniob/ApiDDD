﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiDDD.Domain.Entities
{
    public class StateEntity : BaseEntity
    {
        [Required]
        [MaxLength(2)]
        public string ShortName { get; set; }
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        public IEnumerable<CityEntity> Cities { get; set; }
    }
}
