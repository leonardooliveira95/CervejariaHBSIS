using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Dominio.Entidades
{
    public class Cerveja : EntidadeBase
    {
        public string Nome { get; set; }
        public string Marca { get; set; }
        public string Familia { get; set; }
        public string Estilo { get; set; }
        public float Abv { get; set; }
        public int Ibu { get; set; }
        public List<IngredientesCervejas> Ingredientes { get; set; }
    }
}
