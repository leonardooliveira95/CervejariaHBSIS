using CatalogoCervejas.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Aplicacao.Interfaces
{
    public interface IIngredienteServico
    {
        List<IngredienteViewModel> BuscarTodos();
        IngredienteViewModel Buscar(int id);
        IngredienteViewModel Gravar(IngredienteViewModel ingrediente);
        void Remover(int id);
    }
}
