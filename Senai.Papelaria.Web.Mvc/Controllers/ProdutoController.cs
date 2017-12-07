using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Senai.Papelaria.Dominio.Dominios;
using Senai.Papelaria.Repositorio.Repositorios;

namespace Senai.Papelaria.Web.Mvc.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()   

        {   

            List<Produto> lstProduto = new List<Produto>();  

            try
            {
                ProdutoRep objProdutoRep = new ProdutoRep(); 
                lstProduto = objProdutoRep.Listar().ToList();       
            }

            catch (System.Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }
            return View(lstProduto);
        }   



        [HttpGet]     

        public IActionResult Cadastrar()     
        {     
            CategoriaRep objCategoria = new CategoriaRep();

            var listaCategorias = objCategoria.Listar().ToList();
            
            ViewBag.ListaCategorias = new SelectList(listaCategorias, "IdCategoria", "Titulo");

            return View();     
        }     

        

        [HttpPost]    
        [ValidateAntiForgeryToken]   
        public IActionResult Cadastrar([Bind] Produto Produto)     
        {     
            if (ModelState.IsValid)     
            {     
                ProdutoRep objProdutoRep = new ProdutoRep(); 
                objProdutoRep.Cadastrar(Produto);     

                return RedirectToAction("Index");     
            }     

            return View(Produto);   
        } 

        [HttpGet]   

        public IActionResult Editar(int? id)   

        {   

            if (id == null)   
            {   
                return NotFound();   
            }   

            ProdutoRep objProdutoRep = new ProdutoRep(); 
            Produto Produto = objProdutoRep.BuscarProdutoPorId(id);  

            if (Produto == null)   
            {   
                return NotFound();   
            }   

            CategoriaRep objCategoria = new CategoriaRep();
            var listaCategorias = objCategoria.Listar().ToList();
            
            ViewBag.ListaCategorias = new SelectList(listaCategorias, "IdCategoria", "Titulo");

            return View(Produto);
        }   

        

        [HttpPost]   
        [ValidateAntiForgeryToken]   
        public IActionResult Editar(int id, [Bind]Produto Produto)   
        {   
            if (id != Produto.IdProduto)   
            {   
                return NotFound();   
            }   

            if (ModelState.IsValid)   
            {   
                ProdutoRep objProdutoRep = new ProdutoRep(); 
                objProdutoRep.Atualizar(Produto);   

                return RedirectToAction("Index");   
            }   

            return View(Produto);   
        }  


        [HttpGet]   
        public IActionResult Detalhes(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            ProdutoRep objProdutoRep = new ProdutoRep(); 
            Produto Produto = objProdutoRep.BuscarProdutoPorId(id);  
        

            if (Produto == null)  
            {   
                return NotFound();   
            }   

            return View(Produto);   
        }


        [HttpGet]   
        public IActionResult Excluir(int? id)   
        {   
            if (id == null)   
            {   
                return NotFound();   
            }   

            ProdutoRep objProdutoRep = new ProdutoRep(); 
            Produto Produto = objProdutoRep.BuscarProdutoPorId(id);        

            if (Produto == null)   
            {   
                return NotFound();   
            }   

            return View(Produto);   
        }           

        [HttpPost, ActionName("Excluir")]  
        [ValidateAntiForgeryToken]   
        public IActionResult ExclusaoConfirmada(int? id)   
        {   

            ProdutoRep objProdutoRep = new ProdutoRep(); 
            objProdutoRep.Excluir(id);   

            return RedirectToAction("Index");   
        }


    }
}