using Microsoft.EntityFrameworkCore;
using TaskTracker.Models;
using TaskTracker.Repository.Interfaces;

namespace TaskTracker.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
             * criando um relacionamento de tarefa com usuário, via forengekey usuarioid que é a conexão
               de tarefa com a tabela de usuário, logo, toda tarefa contém um usuário e uma chave para usuário.
             */

            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Usuario)
                .WithMany(u => u.Tarefas)
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade); // Se o usuário for deletado, apaga as tarefas
        }
    }
}
