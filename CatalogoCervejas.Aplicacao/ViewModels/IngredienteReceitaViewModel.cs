using CatalogoCervejas.ViewModels;

namespace CatalogoCervejas.Aplicacao.ViewModels
{
    public class IngredienteReceitaViewModel
    {
        public IngredienteViewModel Ingrediente { get; set; }
        public float Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
    }
}