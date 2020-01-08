using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas_CP.Models.ViewModels
{
    public class FuncionarioViewModel
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int FirstPage { get; set; }

        public int LastPage { get; set; }

        public string StringSearch { get; set; }

    }
}
