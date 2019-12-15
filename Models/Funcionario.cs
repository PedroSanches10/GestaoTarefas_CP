using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas_CP.Models
{
    public class Funcionario
    {
        public int FuncionarioId { get; set; }

        public string Nome_Funcionario { get; set; }

        public string Numero_Funcionario { get; set; }

        public string Password { get; set; }

        public string Morada { get; set; }

        public string CodPostal { get; set; }

        public string Email { get; set; }

        public string Telemovel { get; set; }

        public string NIF { get; set; }

    }
}
