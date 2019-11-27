using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogoCervejas.Dominio.Entidades
{
    public class Ingrediente : EntidadeBase
    {
        public string Nome { get; set; }
        public List<IngredientesCervejas> Cervejas { get; set; }
        public List<IngredientesReceitas> Receitas { get; set; }
    }
}
