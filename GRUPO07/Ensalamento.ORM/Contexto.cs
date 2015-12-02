using Ensalamento.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensalamento.ORM
{
   public class Contexto : DbContext
    {
       //Criando metodo construtor
       public Contexto()
           : base("DbTrainee2015")
       {
       
       }

       //Salas será a tabela no banco de dados.
       public DbSet<Sala> Salas { get; set; }
       public DbSet<Reserva> Reservas { get; set; }
       public DbSet<Bloco> Blocos { get; set; }
       public DbSet<Laboratorio> Laboratorios { get; set; }
       public DbSet<Auditorio> Auditorios { get; set; }
       public DbSet<Categoria> Categorias { get; set; }
       public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
           modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
           modelBuilder.Properties()
                  .Where(p => p.Name == p.ReflectedType.Name + "Id")
                  .Configure(p => p.IsKey());
           modelBuilder.Properties<string>()
                  .Configure(p => p.HasColumnType("varchar"));
           modelBuilder.Properties<string>()
                 .Configure(p => p.HasMaxLength(100));
       }
       
    }
}
