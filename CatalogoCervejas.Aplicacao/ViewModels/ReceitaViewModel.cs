using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Aplicacao.ViewModels
{
    public class ReceitaViewModel
    {
        public int Id { get; set; }
        public string Garrafa { get; set; }
        public CervejaViewModel Cerveja { get; set; }
        public List<IngredienteReceitaViewModel> Ingredientes { get; set; }

    }
}
