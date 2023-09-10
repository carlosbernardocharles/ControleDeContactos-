using ControleDeContactos.Models;
using ControleDeContactos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContactos.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContactoRepositorio _contactoRepositorio1;
        public ContactoController(IContactoRepositorio contactoRepositorio)
        {
            _contactoRepositorio1 = contactoRepositorio;
            
        }

        public IActionResult Index()
        {
           List<ContactoModel> contactos = _contactoRepositorio1.BuscarTodos();
            return View(contactos);
        }

        public IActionResult Criar()
        {
            return View();
        }
        /*
        public IActionResult Editar()
        {
            return View();
        }
        */
        public IActionResult ApagarConfirmacao(int id)
        {
            ContactoModel contacto = _contactoRepositorio1.ListarPorId(id);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Criar(ContactoModel contacto)
        {
           _contactoRepositorio1.Adicionar(contacto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(ContactoModel contacto)
        {
            _contactoRepositorio1.Atualizar(contacto);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            ContactoModel contacto =  _contactoRepositorio1.ListarPorId(id);
            return View(contacto);
        }

        public IActionResult Apagar(int id)
        {
            _contactoRepositorio1.Apagar(id);
            
            return RedirectToAction("Index");  
        }
    }
}
