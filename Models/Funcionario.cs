using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace GestaoTarefas_CP.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage ="Introduza o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza o número")]
        [RegularExpression(@"\d{7}", ErrorMessage = "Número Inválido")]
        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Required(ErrorMessage ="Selecione o cargo ocupado")]
        public string Cargo { get; set; }

        [Required(ErrorMessage = "Introduza a morada")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Introduza o E-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [RegularExpression(@"(2\d{8})|(9[1236]\d{7})", ErrorMessage = "Telemóvel inválido")]
        [Display(Name = "Telemóvel")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Introduza o NIF")]
        [RegularExpression(@"\d{9}", ErrorMessage = "Número de Contribuinte Incorreto")]
        [Display(Name = "Número Contribuinte")]
        public string NIF { get; set; }

    }
}
