using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas_CP.Models
{
    public class Professor
    {

        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "Insera um nome")]
        [StringLength(30, MinimumLength = 4)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Insera um numero de telemóvel")]
        [MaxLength(9)]
        [RegularExpression("(9[1236][0-9]{7})")]
        public string Telemovel { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Insera um Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Insera o seu Gabinete")]
        [MaxLength(3, ErrorMessage = "O nome do Gabinete tem de ter menos de 3 caracteres")]
        public string Gabinete { get; set; }

        [Required]
        public string Disciplina { get; set; }

        internal static decimal Count()
        {
            throw new NotImplementedException();
        }
    }
}
