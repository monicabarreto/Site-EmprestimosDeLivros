using EmprestimosLivros.Data;
using EmprestimosLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimosLivros.Controllers
{
    public class EmprestimosController : Controller
    {
        readonly private ApplicationDbContext _db; //depois do ctor criar esta referencia aqui, e em seguida cita dentro do construtor;
        public EmprestimosController(ApplicationDbContext db) // depois de criar a view e conectar com a model, criar este onstrutor
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var emprestimos = _db.EmprestarLivros.ToList(); //Aqui entra no banco e busca a tabela completa;

            return View(emprestimos);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Cadastrar(EmprestimosModel emprestimos) //depois de indicar a controller no form, coloca os parametros;
        {
            //cria a condição
            if(ModelState.IsValid)//se o estado da model é válido
            {
                _db.EmprestarLivros.Add(emprestimos); //buscou no banco a tabela emprestimos
                _db.SaveChanges();


                return RedirectToAction("Index");

            }
            return View();
        }
        // EDITAR------------------------------
        [HttpGet]
        public IActionResult Editar(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            EmprestimosModel emprestimo = _db.EmprestarLivros.FirstOrDefault(x => x.Id == Id);

            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
            //até aqui é para retornar as informaçoes da tela editar
        }
        [HttpPost]
        public IActionResult Editar(EmprestimosModel emprestimos)
        {
            if(ModelState.IsValid)
            {
                _db.EmprestarLivros.Update(emprestimos);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emprestimos);        
        
        }

        //EXCLUIR-------------------------------------------------------------------------

        [HttpGet]
        public IActionResult Excluir(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            EmprestimosModel emprestimo = _db.EmprestarLivros.FirstOrDefault(x => x.Id == Id); // X É A COLUNA

            if (emprestimo == null)
            {
                return NotFound();
            }
            return View(emprestimo);
        }
        [HttpPost]
        public IActionResult Excluir(EmprestimosModel emprestimos)
        { 
            if(emprestimos == null)
            {
                return NotFound();
            }
            _db.EmprestarLivros.Remove(emprestimos);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
    
    
}
