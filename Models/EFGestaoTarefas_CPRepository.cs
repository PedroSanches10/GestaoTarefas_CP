using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoTarefas_CP.Models
{
    public class EFGestaoTarefas_CPRepository
    {
        private TarefasDbContext db;

        public EFGestaoTarefas_CPRepository(TarefasDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Funcionario> Funcionarios => db.Funcionario;

       // public IEnumerable<Servico> Servicos => db.Servico;
    }
}
