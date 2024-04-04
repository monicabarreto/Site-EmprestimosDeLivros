using EmprestimosLivros.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmprestimosLivros.Data
{
    public class ApplicationDbContext : DbContext //Depois de criar a instancia dbcontext, cria o construtor
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) //construtor, nao precisa incluirir nada, mas percisa colocar os parametros
        {
            //Dentro do options se coloca o nome da classe que foi criada "ApplicationDbContext;
            //na frente coloca o tipo de dados que é o OPTIONS que vai busacar na BASE OPTIONS DO DBCONTEXT;
        }
        public DbSet<EmprestimosModel> EmprestarLivros { get; set;} //Assim que se cria tabela no contexto
    }
}
//e para aparecer a tabela no bando se cria as migrations em console do gerenciador de pacotes;
// em PM> add-migrations criacaodobanco;