using CatalogoCervejas.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Infra.Dados.Contexto
{
    public class SqlServerContext : DbContext
    {
        public DbSet<Ingrediente> Ingrediente { get; set; }
        public DbSet<Cerveja> Cerveja { get; set; }
        public DbSet<IngredientesCervejas> IngredientesCervejas { get; set; }
        public DbSet<Receita> Receita { get; set; }
        public DbSet<IngredientesReceitas> IngredientesReceitas { get; set; }

        public SqlServerContext()
        {
            this.Database.EnsureCreated();
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IngredientesCervejas>()
                .HasKey(x => new { x.IngredienteId, x.CervejaId });

            modelBuilder.Entity<IngredientesCervejas>()
                .HasOne(x => x.Cerveja)
                .WithMany(y => y.Ingredientes)
                .HasForeignKey(z => z.CervejaId);

            modelBuilder.Entity<IngredientesCervejas>()
                .HasOne(x => x.Ingrediente)
                .WithMany(y => y.Cervejas)
                .HasForeignKey(z => z.IngredienteId);


            modelBuilder.Entity<IngredientesReceitas>()
                .HasKey(x => new { x.IngredienteId, x.ReceitaId });

            modelBuilder.Entity<IngredientesReceitas>()
                .HasOne(x => x.Receita)
                .WithMany(y => y.Ingredientes)
                .HasForeignKey(z => z.ReceitaId);

            modelBuilder.Entity<IngredientesReceitas>()
                .HasOne(x => x.Ingrediente)
                .WithMany(y => y.Receitas)
                .HasForeignKey(z => z.IngredienteId);

        }
    }
}
