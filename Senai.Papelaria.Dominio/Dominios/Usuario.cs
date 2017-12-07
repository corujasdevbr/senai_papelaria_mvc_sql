namespace Senai.Papelaria.Dominio.Dominios
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdFuncionario { get; set; }
        public Funcionario Funcionario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
    }
}