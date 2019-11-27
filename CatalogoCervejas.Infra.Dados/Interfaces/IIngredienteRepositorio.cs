using CatalogoCervejas.Dominio.Entidades;
using CatalogoCervejas.Dominio.Interface;
using CatalogoCervejas.Infra.Dados.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Infra.Dados.Interfaces
{
    public interface IIngredienteRepositorio : IRepositorio<Ingrediente>
    {
        void GravarQuantidadeDisponivel();
    }
}
