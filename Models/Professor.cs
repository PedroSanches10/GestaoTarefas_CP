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

        public string Nome { get; set; }

        public string Telemovel { get; set; }
        public string Email { get; set; }
        public string Gabinete { get; set; }
        public string Disciplina { get; set; }
    }
}
