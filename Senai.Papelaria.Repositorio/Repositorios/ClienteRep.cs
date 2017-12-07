using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Papelaria.Dominio.Dominios;

namespace Senai.Papelaria.Repositorio.Repositorios
{
    public class ClienteRep
    {
        string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";   

        /// <summary>

        /// Lista todos os Clientes cadastrados

        /// </summary>

        /// <returns>Retorna uma lista do tipo Cliente</returns>

        public List<Cliente> Listar()   

        {   

            List<Cliente> lstCliente = new List<Cliente>();  

            try
            {
                //Outra forma de instanciar um objeto
                using (SqlConnection con = new SqlConnection(connectionString))   
                {                       
                    //instrução sql para listar os Clientes
                    string sqlQuery = "Select * from Clientes";   

                    SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                    con.Open();   

                    SqlDataReader rdr = cmd.ExecuteReader();   
   

                    while (rdr.Read())   
                    {   
                        Cliente Cliente = new Cliente();   
                        Cliente.IdCliente = Convert.ToInt32(rdr["IdClientes"]);   
                        Cliente.NomeCliente = rdr["NomeCliente"].ToString(); 
                        Cliente.Email = rdr["Email"].ToString(); 
                        Cliente.Cpf = rdr["Cpf"].ToString(); 
                        Cliente.DataCadastro = Convert.ToDateTime(rdr["DataCadastro"]); 
                        lstCliente.Add(Cliente);   
                    }   

                    con.Close();   
                }   

            }

            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstCliente;   
        }   

   

        /// <summary>
        /// Cadastra um Cliente
        /// </summary>
        /// <param name="Cliente">Parametro de entrada do tipo Cliente</param>    
        public void Cadastrar(Cliente Cliente)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para cadastrar o Cliente
                string sqlQuery = "insert into Clientes(nomecliente, email, cpf, datacadastro) values('"+ Cliente.NomeCliente+ "','"+ Cliente.Email+ "','"+ Cliente.Cpf+ "','"+ Cliente.DataCadastro+ "')";   

                SqlCommand cmd = new SqlCommand(sqlQuery, con); 
                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   
            }   

        }   

   

        /// <summary>
        /// Atualiza um Cliente
        /// </summary>
        /// <param name="Cliente">Atualiza um Cliente</param>
        public void Atualizar(Cliente Cliente)   
        {   

            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para atualizar o Cliente
                string sqlQuery = "update Clientes set nomecliente='"+ Cliente.NomeCliente +"', email='"+ Cliente.Email+"', cpf='"+ Cliente.Cpf+ "',datacadastro='" + Cliente.DataCadastro+"' where idclientes=" + Cliente.IdCliente ;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   
            }   
        }   

   

        /// <summary>
        /// Busca um Cliente pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do Cliente a ser mostrado</param> 
        public Cliente BuscarClientePorId(int? id)   
        {   

              Cliente Cliente = null;

            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para buscar o Cliente pelo Id
                string sqlQuery = "select * from clientes where idclientes = " + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                SqlDataReader rdr = cmd.ExecuteReader();     

                while (rdr.Read())   
                {   

                    Cliente = new Cliente();   
                    Cliente.IdCliente = Convert.ToInt32(rdr["IdClientes"]);   
                    Cliente.NomeCliente = rdr["NomeCliente"].ToString(); 
                    Cliente.Email = rdr["Email"].ToString(); 
                    Cliente.Cpf = rdr["Cpf"].ToString(); 
                    Cliente.DataCadastro = Convert.ToDateTime(rdr["DataCadastro"]); 
                }   

            }   

            return Cliente;   

        }   

   

        /// <summary>
        /// Exclui um Cliente pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do Cliente a ser excluido</param>  
        public void Excluir(int? id)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para excluir o Cliente pelo Id
                string sqlQuery = "delete from clientes where idclientes =" + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   

            }   

        }   
    }
}