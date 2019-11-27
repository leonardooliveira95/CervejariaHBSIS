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
    public class CervejaRepositorio : RepositorioBase<Cerveja>,ICervejaRepositorio
    {
        private readonly SqlServerContext _context;

        public CervejaRepositorio(SqlServerContext context) : base(context)
        {
            this._context = context;
        }

        public override Cerveja Buscar(int id)
        {
            Cerveja c = _context.Cerveja.Include(x => x.Ingredientes).Include("Ingredientes.Ingrediente").Where(x => x.Id == id).FirstOrDefault();
            

            return c;
        }

        public override IList<Cerveja> BuscarTodos()
        {
            return _context.Cerveja.Include(x => x.Ingredientes).Include("Ingredientes.Ingrediente").ToList();
        }

        public override void Atualizar(Cerveja obj)
        {
            //TODO: PERMITIR ALTERAÇÃO DOS INGREDIENTES
            base.Atualizar(obj);
        }
    }
}
