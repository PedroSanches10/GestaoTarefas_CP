using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestaoTarefas_CP.Models;

public class TarefasDbContext : DbContext
{
    public TarefasDbContext(DbContextOptions<TarefasDbContext> options)
        : base(options)
    {
    }

    public DbSet<GestaoTarefas_CP.Models.Professor> Professor { get; set; }

    public DbSet<GestaoTarefas_CP.Models.Funcionario> Funcionario { get; set; }

}