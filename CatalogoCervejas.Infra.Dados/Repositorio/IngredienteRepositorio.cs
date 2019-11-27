using CatalogoCervejas.Dominio.Entidades;
using CatalogoCervejas.Infra.Dados.Contexto;
using CatalogoCervejas.Infra.Dados.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Infra.Dados.Repositorio
{
    public class IngredienteRepositorio : RepositorioBase<Ingrediente>, IIngredienteRepositorio
    {
        public IngredienteRepositorio(SqlServerContext context) : base(context)
        {
            
        }

        public void GravarQuantidadeDisponivel()
        {
            throw new NotImplementedException();
        }
    }
}
