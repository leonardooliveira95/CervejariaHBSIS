using CatalogoCervejas.Dominio.Entidades;
using CatalogoCervejas.Dominio.Interface;
using CatalogoCervejas.Infra.Dados.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CatalogoCervejas.Infra.Dados.Repositorio
{
    public class RepositorioBase<T> : IRepositorio<T> where T : EntidadeBase
    {
        private SqlServerContext _context;

        public RepositorioBase(SqlServerContext context)
        {
            this._context = context;
        }

        public void Remover(int id)
        {
            _context.Set<T>().Remove(Buscar(id));
            _context.SaveChanges();
        }

        public virtual void Atualizar(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual T Buscar(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IList<T> BuscarTodos()
        {
            return _context.Set<T>().ToList();
        }

        public void Inserir(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }
    }
}
