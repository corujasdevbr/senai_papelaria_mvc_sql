namespace Senai.Papelaria.Dominio.Dominios
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string NomeProduto { get; set; }
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}