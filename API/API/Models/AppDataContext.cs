using System;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class AppDataContext : DbContext
{
    public DbSet<IMC> IMCs { get; set;} 
    public DbSet<Aluno> Alunos { get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=BrunoTrevizanRizzatto.db");
    }
}
