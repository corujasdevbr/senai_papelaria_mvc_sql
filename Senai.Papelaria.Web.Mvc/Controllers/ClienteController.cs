using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.Papelaria.Dominio.Dominios;
using Senai.Papelaria.Repositorio.Repositorios;

namespace Senai.Papelaria.Web.Mvc.Controllers
{
    public class ClienteController: Controller

    {

         

   

    // GET: /<controller>/   

        public IActionResult Index()   

        {   

            List<Cliente> lstCliente = new List<Cliente>();  

            try

            {
                ClienteRep objClienteRep = new ClienteRep(); 
                lstCliente = objClienteRep.Listar().ToList();       

            }

            catch (System.Exception ex)

            {

                TempData["Erro"] = ex.Message;

            }



            return View(lstCliente);

            

        }   



        [HttpGet]     

        public IActionResult Cadastrar()     

        {     

            return View();     

        }     

        

        [HttpPost]     

        [ValidateAntiForgeryToken]     

        public IActionResult Cadastrar([Bind] Cliente Cliente)     

        {     

            if (ModelState.IsValid)     

            {     
                ClienteRep objClienteRep = new ClienteRep(); 
                objClienteRep.Cadastrar(Cliente);     

                return RedirectToAction("Index");     

            }     

            return View(Cliente);     

        } 



        [HttpGet]   

        public IActionResult Editar(int? id)   

        {   

            if (id == null)   
            {   
                return NotFound();   
            }   

            ClienteRep objClienteRep = new ClienteRep(); 
            Cliente Cliente = objClienteRep.BuscarClientePorId(id);  

            if (Cliente == null)   
            {   
                return NotFound();   
            }   

            return View(Cliente);
        }   

        

        [HttpPost]   
        [ValidateAntiForgeryToken]   
        public IActionResult Editar(int id, [Bind]Cliente Cliente)   
        {   
            if (id != Cliente.IdCliente)   
            {   
                return NotFound();   
            }   

            if (ModelState.IsValid)   
            {   
                ClienteRep objClienteRep = new ClienteRep(); 
                objClienteRep.Atualizar(Cliente);   

                return RedirectToAction("Index");   
            }   

            return View(Cliente);   
        }  


        [HttpGet]   
        public IActionResult Detalhes(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            ClienteRep objClienteRep = new ClienteRep(); 
            Cliente Cliente = objClienteRep.BuscarClientePorId(id);  
        

            if (Cliente == null)  
            {   
                return NotFound();   
            }   

            return View(Cliente);   
        }


        [HttpGet]   
        public IActionResult Excluir(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            ClienteRep objClienteRep = new ClienteRep(); 
            Cliente Cliente = objClienteRep.BuscarClientePorId(id);        

            if (Cliente == null)   
            {   
                return NotFound();   
            }   

            return View(Cliente);   
        }           

        [HttpPost, ActionName("Excluir")]  
        [ValidateAntiForgeryToken]   
        public IActionResult ExclusaoConfirmada(int? id)   
        {   

            ClienteRep objClienteRep = new ClienteRep(); 
            objClienteRep.Excluir(id);   

            return RedirectToAction("Index");   
        }
    }
}