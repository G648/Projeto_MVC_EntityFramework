using Microsoft.EntityFrameworkCore;
using Projeto_Gamer_MVC.Models;

namespace Projeto_Gamer_MVC.Infra
{
    public class Context : DbContext
    {
        //pasta criada para acessar o BANCO DE DADOS    
        //vai herdar de uma classe nativa do c#

        public Context()
        {

        }

        //construtor responsável 
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // STRING DE CONEXÃO
                //aqui escolhemos a opção de banco de dados, graças aos pacotes que baixamos anteriormente
                //data source == nome do servidor do gerenciados do banco
                //initial catalog == nome do banco de dados

                //AUTENTICAÇÃO PELO WINDOWS
                //intergrated security == Autenticação pelo windows
                //TrustServerCertificate == Autenticação pelo windows 

                //AUTENTICAÇÃO PELO SQLSERVER
                //user Id = "nome do usuário de login do banco de dados"
                //pwd = "nome da senha do banco de dados"

                optionsBuilder.UseSqlServer("Data Source = NOTE15-S15; Initial Catalog = projetoGamerManhaMVC; User Id = sa; pwd = Senai@134; TrustServerCertificate = true"); // --> gerenciador do banco de dados

            }
        }

        //referencia das tabelas no banco de dados
        public DbSet<Jogador> Jogador {get; set;}
        public DbSet<Equipe> Equipe {get; set;}
    }
}