namespace Senai.Papelaria.Dominio.Dominios
{
    public class Estoque
    {
        public int IdEstoque { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}