using CatalogoCervejas.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Aplicacao.ViewModels
{
    public class CervejaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string Estilo { get; set; }
        public float Abv { get; set; }
        public int Ibu { get; set; }
        public List<IngredienteViewModel> Ingredientes { get; set; }
    }
}
