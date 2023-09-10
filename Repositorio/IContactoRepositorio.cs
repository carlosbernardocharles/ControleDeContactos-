using ControleDeContactos.Models;

namespace ControleDeContactos.Repositorio
{
    public interface IContactoRepositorio
    {
        ContactoModel ListarPorId(int id);
        List<ContactoModel> BuscarTodos();
        ContactoModel Adicionar(ContactoModel contacto);
        ContactoModel Atualizar(ContactoModel contacto);
        bool Apagar(int id);
    }
   
}
