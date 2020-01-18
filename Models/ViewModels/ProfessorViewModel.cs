using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas_CP.Models.ViewModels
{
    public class ProfessorViewModel
    {
        public IEnumerable <Professor> Professors { get; set; }

        public int Pagina_Atual { get; set; }

        public int Total_Paginas { get; set; }

        public int Primeira_Pagina { get; set; }

        public int Ultima_Pagina { get; set; }

        public string SearchString { get; set; }
    }
}
