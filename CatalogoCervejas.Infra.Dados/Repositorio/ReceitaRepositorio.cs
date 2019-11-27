using CatalogoCervejas.Dominio.Entidades;
using CatalogoCervejas.Infra.Dados.Contexto;
using CatalogoCervejas.Infra.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CatalogoCervejas.Infra.Dados.Repositorio
{
    public class ReceitaRepositorio : RepositorioBase<Receita>, IReceitaRepositorio
    {
        private readonly SqlServerContext _context;

        public ReceitaRepositorio(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            this._context = sqlServerContext;
        }

        public override IList<Receita> BuscarTodos()
        {
            return _context.Receita.Include(x => x.Cerveja).Include(x => x.Ingredientes).Include("Ingredientes.Ingrediente").ToList();
        }
    }
}
