using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Senai.Papelaria.Dominio.Dominios;
using Senai.Papelaria.Repositorio.Repositorios;

namespace Senai.Papelaria.Web.Mvc.Controllers
{
    public class CategoriaController : Controller

    {

         

   

    // GET: /<controller>/   

        public IActionResult Index()   

        {   

            List<Categoria> lstCategoria = new List<Categoria>();  

            try

            {
                CategoriaRep objCategoriaRep = new CategoriaRep(); 
                lstCategoria = objCategoriaRep.Listar().ToList();       

            }

            catch (System.Exception ex)

            {

                TempData["Erro"] = ex.Message;

            }



            return View(lstCategoria);

            

        }   



        [HttpGet]     

        public IActionResult Cadastrar()     

        {     

            return View();     

        }     

        

        [HttpPost]     

        [ValidateAntiForgeryToken]     

        public IActionResult Cadastrar([Bind] Categoria Categoria)     

        {     

            if (ModelState.IsValid)     

            {     
                CategoriaRep objCategoriaRep = new CategoriaRep(); 
                objCategoriaRep.Cadastrar(Categoria);     

                return RedirectToAction("Index");     

            }     

            return View(Categoria);     

        } 



        [HttpGet]   

        public IActionResult Editar(int? id)   

        {   

            if (id == null)   
            {   
                return NotFound();   
            }   

            CategoriaRep objCategoriaRep = new CategoriaRep(); 
            Categoria Categoria = objCategoriaRep.BuscarCategoriaPorId(id);  

            if (Categoria == null)   
            {   
                return NotFound();   
            }   

            return View(Categoria);
        }   

        

        [HttpPost]   
        [ValidateAntiForgeryToken]   
        public IActionResult Editar(int id, [Bind]Categoria Categoria)   
        {   
            if (id != Categoria.IdCategoria)   
            {   
                return NotFound();   
            }   

            if (ModelState.IsValid)   
            {   
                CategoriaRep objCategoriaRep = new CategoriaRep(); 
                objCategoriaRep.Atualizar(Categoria);   

                return RedirectToAction("Index");   
            }   

            return View(Categoria);   
        }  


        [HttpGet]   
        public IActionResult Detalhes(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            CategoriaRep objCategoriaRep = new CategoriaRep(); 
            Categoria Categoria = objCategoriaRep.BuscarCategoriaPorId(id);  
        

            if (Categoria == null)  
            {   
                return NotFound();   
            }   

            return View(Categoria);   
        }


        [HttpGet]   
        public IActionResult Excluir(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            CategoriaRep objCategoriaRep = new CategoriaRep(); 
            Categoria Categoria = objCategoriaRep.BuscarCategoriaPorId(id);        

            if (Categoria == null)   
            {   
                return NotFound();   
            }   

            return View(Categoria);   
        }           

        [HttpPost, ActionName("Excluir")]  
        [ValidateAntiForgeryToken]   
        public IActionResult ExclusaoConfirmada(int? id)   
        {   

            CategoriaRep objCategoriaRep = new CategoriaRep(); 
            objCategoriaRep.Excluir(id);   

            return RedirectToAction("Index");   
        }
    }
}