using CatalogoCervejas.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Aplicacao.Interfaces
{
    public interface IReceitaServico
    {
        ReceitaViewModel Gravar(ReceitaViewModel receitaViewModel);
        List<ReceitaViewModel> BuscarTodos();
    }
}
