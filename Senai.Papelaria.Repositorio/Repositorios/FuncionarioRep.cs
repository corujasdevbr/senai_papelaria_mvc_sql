using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Senai.Papelaria.Dominio.Dominios;

namespace Senai.Papelaria.Repositorio.Repositorios
{
    public class FuncionarioRep
    {
        
        string connectionString = @"Data Source=.\SqlExpress;Initial Catalog=Papelaria; uid=sa; pwd=senai@123";   

        /// <summary>

        /// Lista todos os Funcionarios cadastrados

        /// </summary>

        /// <returns>Retorna uma lista do tipo Funcionario</returns>

        public List<Funcionario> Listar()   

        {   

            List<Funcionario> lstFuncionario = new List<Funcionario>();  

            try
            {
                //Outra forma de instanciar um objeto
                using (SqlConnection con = new SqlConnection(connectionString))   
                {                       
                    //instrução sql para listar os Funcionarios
                    string sqlQuery = "Select * from Funcionarios";   

                    SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                    con.Open();   

                    SqlDataReader rdr = cmd.ExecuteReader();   
   

                    while (rdr.Read())   
                    {   
                        Funcionario Funcionario = new Funcionario();   
                        Funcionario.IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]);   
                        Funcionario.NomeFuncionario = rdr["NomeFuncionario"].ToString(); 
                        Funcionario.Cargo = rdr["Cargo"].ToString(); 
                        Funcionario.Departamento = rdr["Departamento"].ToString(); 
                        lstFuncionario.Add(Funcionario);   
                    }   

                    con.Close();   
                }   

            }

            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lstFuncionario;   
        }   

   

        /// <summary>
        /// Cadastra um Funcionario
        /// </summary>
        /// <param name="Funcionario">Parametro de entrada do tipo Funcionario</param>    
        public void Cadastrar(Funcionario Funcionario)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para cadastrar o Funcionario
                string sqlQuery = "insert into Funcionarios(nomefuncionario, cargo, departamento) values ('" + Funcionario.NomeFuncionario +"','" + Funcionario.Cargo +"','" + Funcionario.Departamento +"')";   

                SqlCommand cmd = new SqlCommand(sqlQuery, con); 
                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   
            }   

        }   

   

        /// <summary>
        /// Atualiza um Funcionario
        /// </summary>
        /// <param name="Funcionario">Atualiza um Funcionario</param>
        public void Atualizar(Funcionario Funcionario)   
        {   

            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para atualizar o Funcionario
                string sqlQuery = "update Funcionarios set nomefuncionario='" + Funcionario.NomeFuncionario + "',cargo='" + Funcionario.Cargo + "',departamento='" + Funcionario.Departamento + "' where idFuncionario=" + Funcionario.IdFuncionario ;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   
            }   
        }   

   

        /// <summary>
        /// Busca um Funcionario pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do Funcionario a ser mostrado</param> 
        public Funcionario BuscarFuncionarioPorId(int? id)   
        {   

            Funcionario Funcionario = new Funcionario();     

            using (SqlConnection con = new SqlConnection(connectionString))   
            {   
                //Instrução sql para buscar o Funcionario pelo Id
                string sqlQuery = "select * from Funcionarios where idFuncionario=" + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                SqlDataReader rdr = cmd.ExecuteReader();     

                while (rdr.Read())   
                {   
                    Funcionario.IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]);   
                    Funcionario.NomeFuncionario = rdr["NomeFuncionario"].ToString(); 
                    Funcionario.Cargo = rdr["Cargo"].ToString(); 
                    Funcionario.Departamento = rdr["Departamento"].ToString(); 
                }   

            }   

            return Funcionario;   

        }   

   

        /// <summary>
        /// Exclui um Funcionario pelo Id
        /// </summary>
        /// <param name="id">Parametro de entrada do tipo int com o Id do Funcionario a ser excluido</param>  
        public void Excluir(int? id)   
        {   
            using (SqlConnection con = new SqlConnection(connectionString))   
            {   

                //Instrução sql para excluir o Funcionario pelo Id
                string sqlQuery = "delete from Funcionarios where idFuncionario=" + id;   
                SqlCommand cmd = new SqlCommand(sqlQuery, con);    

                con.Open();   

                cmd.ExecuteNonQuery();   

                con.Close();   

            }   

        }   

    }
}