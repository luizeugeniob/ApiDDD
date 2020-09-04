using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDDD.Domain.Dtos.Address
{
    public class AddressDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "CEP é obrigatório.")]
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Logradouro é obrigatório.")]
        public string Street { get; set; }
        public string Number { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatória.")]
        public Guid CityId { get; set; }
    }
}
