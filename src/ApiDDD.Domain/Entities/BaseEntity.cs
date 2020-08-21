﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDDD.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        private DateTime? _createdAt;
        public DateTime? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null ? DateTime.Now : value); }
        }

        public DateTime? updatedAt { get; set; }

    }
}
