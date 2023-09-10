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

        public bool Apagar(int id)
        {
            ContactoModel contacto = ListarPorId(id);
            if (contacto == null)
            {
                throw new Exception("Houve um erro na Remocao de contacto!");
            }
            _bancoContext.Contactos.Remove(contacto);
            _bancoContext.SaveChanges();
            return true;
        }

        public ContactoModel Atualizar(ContactoModel contacto)
        {
            ContactoModel contactoDB = ListarPorId(contacto.Id);
            if(contactoDB == null)
            {
                throw new Exception("Houve um erro na atualizacao do contacto!");
                
            }
            contactoDB.NomeContacto = contacto.NomeContacto;
            contactoDB.Celular  =   contacto.Celular;
            contactoDB.Email = contacto.Email;

            _bancoContext.Contactos.Update(contactoDB);
            _bancoContext.SaveChanges();

            return contactoDB;
        }

        public List<ContactoModel> BuscarTodos()
        {
            return _bancoContext.Contactos.ToList();
        }

        public ContactoModel ListarPorId(int id)
        {
            return _bancoContext.Contactos.FirstOrDefault(x => x.Id == id);
        }
    }
}
