using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDDD.Data.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        private DateTimeOffset? _createdAt;
        public DateTimeOffset? CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = (value == null ? DateTimeOffset.Now : value); }
        }

        public DateTimeOffset? updatedAt { get; set; }

    }
}
