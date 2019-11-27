using CatalogoCervejas.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Aplicacao.Interfaces
{
    public interface ICervejaServico
    {
        List<CervejaViewModel> BuscarTodos();
        CervejaViewModel Buscar(int id);
        CervejaViewModel Gravar(CervejaViewModel ingrediente);
        void Remover(int id);
    }
}
