using ControleDeContactos.Data;
using ControleDeContactos.Models;

namespace ControleDeContactos.Repositorio
{
    public class ContactoRepositorio : IContactoRepositorio
    {
        private readonly BancoContext _bancoContext;//apenas o contexto deve ter accesso ao BD
        public ContactoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        
        /// <summary>
        /// Metodo responsavel por add Contacto a BD
        /// </summary>
        /// <param name="contacto">Contacto a ser adicionado</param>
        /// <returns>contacto</returns>
        public ContactoModel Adicionar(ContactoModel contacto)
        {
            //Gravar no banco de dados
            _bancoContext.Contactos.Add(contacto);
            _bancoContext.SaveChanges();
            return contacto;
        }

        public List<ContactoModel> BuscarTodos()
        {
            return _bancoContext.Contactos.ToList();
        }
    }
}
