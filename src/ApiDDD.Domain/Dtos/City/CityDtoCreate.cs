using System;
using System.ComponentModel.DataAnnotations;

namespace ApiDDD.Domain.Dtos.City
{
    public class CityDtoCreate
    {
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido.")]
        public int IBGECode { get; set; }
        [Required(ErrorMessage = "Estado é obrigatório.")]
        public Guid StateId { get; set; }
    }
}
