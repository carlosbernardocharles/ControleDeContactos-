using ControleDeContactos.Models;

namespace ControleDeContactos.Repositorio
{
    public interface IContactoRepositorio
    {
        List<ContactoModel> BuscarTodos();
        ContactoModel Adicionar(ContactoModel contacto);
    }
}
