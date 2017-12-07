using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Papelaria.Dominio.Dominios;

namespace Senai.Papelaria.Repositorio.Repositorios
{
    public class CategoriaRep
    {
        string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";   

        /// <summary>

        /// Lista todos os Categorias cadastrados

        /// </summary>

        /// <returns>Retorna uma lista do tipo Categoria</returns>

        public List<Categoria> Listar()   

        {   

            List<Categoria> lstCategoria = new List<Categoria>();  

            try
            {
                //Outra forma de instanciar um objeto
                using (SqlConnection con = new SqlConnection(connectionString))   
                {                       
                    //instrução sql para listar os Categorias
                    string sqlQuery = "Select * from categorias";   

                    SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                    con.Open();   

                    SqlDataReader rdr = cmd.ExecuteReader();   
   

                    while (rdr.Read())   
                    {   
                        Categoria Categoria = new Categoria();   
                        Categoria.IdCategoria = Convert.ToInt32(rdr["IdCategoria"]);   
                        Categoria.Titulo = rdr["Titulo"].ToString(); 
                        lstCategoria.Add(Categoria);   
                    }   

                    con.Close();   
                }   

            }

            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstCategoria;   
        }   

   

        /// <summary>
        /// Cadastra um Categoria
        /// </summary>
        /// <param name="Categoria">Parametro de entrada do tipo Categoria</param>    
        public void Cadastrar(Categoria Categoria)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para cadastrar o Categoria
                string sqlQuery = "insert into categorias(titulo) values ('" + Categoria.Titulo +"')";   

                SqlCommand cmd = new SqlCommand(sqlQuery, con); 
                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   
            }   

        }   

   

        /// <summary>
        /// Atualiza um Categoria
        /// </summary>
        /// <param name="Categoria">Atualiza um Categoria</param>
        public void Atualizar(Categoria Categoria)   
        {   

            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para atualizar o Categoria
                string sqlQuery = "update Categorias set titulo='" + Categoria.Titulo + "' where idcategoria=" + Categoria.IdCategoria ;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   
            }   
        }   

   

        /// <summary>
        /// Busca um Categoria pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do Categoria a ser mostrado</param> 
        public Categoria BuscarCategoriaPorId(int? id)   
        {   

            Categoria Categoria = new Categoria();     

            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para buscar o Categoria pelo Id
                string sqlQuery = "select * from categorias where idcategoria=" + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                SqlDataReader rdr = cmd.ExecuteReader();     

                while (rdr.Read())   
                {   
                    Categoria.IdCategoria = Convert.ToInt32(rdr["IdCategoria"]);   

                    Categoria.Titulo = rdr["Titulo"].ToString();
                }   

            }   

            return Categoria;   

        }   

   

        /// <summary>
        /// Exclui um Categoria pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do Categoria a ser excluido</param>  
        public void Excluir(int? id)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para excluir o Categoria pelo Id
                string sqlQuery = "delete from Categorias where idcategoria=" + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   

            }   

        }   

    }
}
