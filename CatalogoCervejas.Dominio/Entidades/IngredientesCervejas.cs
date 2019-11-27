using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Dominio.Entidades
{
    public class IngredientesCervejas
    {
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }
        public int CervejaId { get; set; }
        public Cerveja Cerveja { get; set; }
    }
}
