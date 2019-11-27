using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Dominio.Entidades
{
    public class Receita : EntidadeBase
    {
        public string Garrafa { get; set; }
        public int CervejaId { get; set; }
        public Cerveja Cerveja { get; set; }
        public List<IngredientesReceitas> Ingredientes { get; set; }
    }
}
