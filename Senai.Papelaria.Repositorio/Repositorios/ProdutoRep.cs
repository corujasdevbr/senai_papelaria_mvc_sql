using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Papelaria.Dominio.Dominios;

namespace Senai.Papelaria.Repositorio.Repositorios
{
    public class ProdutoRep
    {
        string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";   

        /// <summary>
        /// Lista todos os Produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista do tipo Produto</returns>
        public List<Produto> Listar()   

        {   

            List<Produto> lstProduto = new List<Produto>();  

            try
            {
                //Outra forma de instanciar um objeto
                using (SqlConnection con = new SqlConnection(connectionString))   
                {                       
                    //instrução sql para listar os Produtos
                    string sqlQuery = "Select * from Produtos";   

                    SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                    con.Open();   

                    SqlDataReader rdr = cmd.ExecuteReader();   
   

                    while (rdr.Read())   
                    {   
                        Produto Produto = new Produto();   
                        Produto.IdProduto = Convert.ToInt32(rdr["IdProduto"]);   
                        Produto.NomeProduto = rdr["NomeProduto"].ToString(); 
                        Produto.Descricao = rdr["Descricao"].ToString(); 
                        Produto.IdCategoria = Convert.ToInt32(rdr["IdCategoria"]); 
                        Produto.Preco = Convert.ToDecimal(rdr["Preco"]); 
                        lstProduto.Add(Produto);   
                    }   

                    con.Close();   
                }   

            }

            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstProduto;   
        }   

   

        /// <summary>
        /// Cadastra um Produto
        /// </summary>
        /// <param name="Produto">Parametro de entrada do tipo Produto</param>    
        public void Cadastrar(Produto Produto)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para cadastrar o Produto
                string sqlQuery = "insert into Produtos(nomeProduto, descricao, idcategoria, preco) values('"+ Produto.NomeProduto+ "','"+ Produto.Descricao+ "',"+ Produto.IdCategoria+ ",'"+ Produto.Preco+ "')";   

                SqlCommand cmd = new SqlCommand(sqlQuery, con); 
                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   
            }   

        }   

   

        /// <summary>
        /// Atualiza um Produto
        /// </summary>
        /// <param name="Produto">Atualiza um Produto</param>
        public void Atualizar(Produto Produto)   
        {   

            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para atualizar o Produto
                string sqlQuery = "update Produtos set nomeProduto='"+ Produto.NomeProduto +"', descricao='"+ Produto.Descricao+"', idCategoria="+ Produto.IdCategoria+ ",preco=" + Produto.Preco+" where idProduto=" + Produto.IdProduto ;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   
            }   
        }   

   

        /// <summary>
        /// Busca um Produto pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do Produto a ser mostrado</param> 
        public Produto BuscarProdutoPorId(int? id)   
        {   

              Produto Produto = null;

            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para buscar o Produto pelo Id
                string sqlQuery = "select * from Produtos where idProduto = " + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                SqlDataReader rdr = cmd.ExecuteReader();     

                while (rdr.Read())   
                {   

                    Produto = new Produto();     
                    Produto.IdProduto = Convert.ToInt32(rdr["IdProduto"]);   
                    Produto.NomeProduto = rdr["NomeProduto"].ToString(); 
                    Produto.Descricao = rdr["Descricao"].ToString(); 
                    Produto.IdCategoria = Convert.ToInt32(rdr["IdCategoria"]); 
                    Produto.Preco = Convert.ToDecimal(rdr["Preco"]); 
                }   

            }   

            return Produto;   

        }   

   

        /// <summary>
        /// Exclui um Produto pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do Produto a ser excluido</param>  
        public void Excluir(int? id)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para excluir o Produto pelo Id
                string sqlQuery = "delete from Produtos where idProduto =" + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   

            }   

        }  
    }
}