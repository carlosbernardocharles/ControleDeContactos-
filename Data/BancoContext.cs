using ControleDeContactos.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContactos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
            
        }

        public DbSet<ContactoModel> Contactos { get; set; }
    }
}
