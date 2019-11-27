namespace CatalogoCervejas.Dominio.Entidades
{
    public class IngredientesReceitas
    {
        public int IngredienteId { get; set; }
        public Ingrediente Ingrediente { get; set; }
        public int ReceitaId { get; set; }
        public Receita Receita { get; set; }
        public float Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
    }
}