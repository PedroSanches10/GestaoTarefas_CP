using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas_CP.Models
{
    public class Cargo
    {
        public int CargoId { get; set; }

        public string Nome_Cargo { get; set; }

        public string Escola_Cargo { get; set; }

        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }


    }
}
