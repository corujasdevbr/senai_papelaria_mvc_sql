using System;

namespace Senai.Papelaria.Dominio.Dominios
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; }
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }
        public DateTime DataPedido { get; set; }
    }
}