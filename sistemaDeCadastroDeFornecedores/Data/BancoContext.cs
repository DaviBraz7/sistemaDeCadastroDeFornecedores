using Microsoft.EntityFrameworkCore;
using sistemaDeCadastroDeFornecedores.Models;

namespace sistemaDeCadastroDeFornecedores.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }

        public DbSet<FornecedorModel> Fornecedor { get; set; }
    }
}
