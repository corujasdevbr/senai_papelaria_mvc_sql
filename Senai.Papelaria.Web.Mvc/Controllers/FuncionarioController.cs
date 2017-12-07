using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.Papelaria.Dominio.Dominios;
using Senai.Papelaria.Repositorio.Repositorios;

namespace Senai.Papelaria.Web.Mvc.Controllers
{
    public class FuncionarioController: Controller

    {

         

   

    // GET: /<controller>/   

        public IActionResult Index()   

        {   

            List<Funcionario> lstFuncionario = new List<Funcionario>();  

            try

            {
                FuncionarioRep objFuncionarioRep = new FuncionarioRep(); 
                lstFuncionario = objFuncionarioRep.Listar().ToList();       

            }

            catch (System.Exception ex)

            {

                TempData["Erro"] = ex.Message;

            }



            return View(lstFuncionario);

            

        }   



        [HttpGet]     

        public IActionResult Cadastrar()     

        {     

            return View();     

        }     

        

        [HttpPost]     

        [ValidateAntiForgeryToken]     

        public IActionResult Cadastrar([Bind] Funcionario Funcionario)     

        {     

            if (ModelState.IsValid)     

            {     
                FuncionarioRep objFuncionarioRep = new FuncionarioRep(); 
                objFuncionarioRep.Cadastrar(Funcionario);     

                return RedirectToAction("Index");     

            }     

            return View(Funcionario);     

        } 



        [HttpGet]   

        public IActionResult Editar(int? id)   

        {   

            if (id == null)   
            {   
                return NotFound();   
            }   

            FuncionarioRep objFuncionarioRep = new FuncionarioRep(); 
            Funcionario Funcionario = objFuncionarioRep.BuscarFuncionarioPorId(id);  

            if (Funcionario == null)   
            {   
                return NotFound();   
            }   

            return View(Funcionario);
        }   

        

        [HttpPost]   
        [ValidateAntiForgeryToken]   
        public IActionResult Editar(int id, [Bind]Funcionario Funcionario)   
        {   
            if (id != Funcionario.IdFuncionario)   
            {   
                return NotFound();   
            }   

            if (ModelState.IsValid)   
            {   
                FuncionarioRep objFuncionarioRep = new FuncionarioRep(); 
                objFuncionarioRep.Atualizar(Funcionario);   

                return RedirectToAction("Index");   
            }   

            return View(Funcionario);   
        }  


        [HttpGet]   
        public IActionResult Detalhes(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            FuncionarioRep objFuncionarioRep = new FuncionarioRep(); 
            Funcionario Funcionario = objFuncionarioRep.BuscarFuncionarioPorId(id);  
        

            if (Funcionario == null)  
            {   
                return NotFound();   
            }   

            return View(Funcionario);   
        }


        [HttpGet]   
        public IActionResult Excluir(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            FuncionarioRep objFuncionarioRep = new FuncionarioRep(); 
            Funcionario Funcionario = objFuncionarioRep.BuscarFuncionarioPorId(id);        

            if (Funcionario == null)   
            {   
                return NotFound();   
            }   

            return View(Funcionario);   
        }           

        [HttpPost, ActionName("Excluir")]  
        [ValidateAntiForgeryToken]   
        public IActionResult ExclusaoConfirmada(int? id)   
        {   

            FuncionarioRep objFuncionarioRep = new FuncionarioRep(); 
            objFuncionarioRep.Excluir(id);   

            return RedirectToAction("Index");   
        }
    }
}