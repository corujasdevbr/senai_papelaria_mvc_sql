namespace Senai.Papelaria.Dominio.Dominios
{
    public class DetalhesPedido
    {
        public int IdDetalhe { get; set; }
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
        public int QuantidadeComprada { get; set; }
    }
}