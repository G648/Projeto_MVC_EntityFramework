using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//dotnet dev-certs https --trust --> criando o certificado de confiança para acessar a página HTML

namespace Projeto_Gamer_MVC.Models
{
    public class Jogador //cada classe vira uma tabela no banco de dados
    {
        [Key]
        public int IdJogador { get; set; }

        [Required(ErrorMessage = "O nome de usuário é obrigatório neste campo!", AllowEmptyStrings = false)] //usando o data annotation para ser obrigatório digitar o nome
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório neste campo!", AllowEmptyStrings = false)]
        public string? Email { get; set; }
        public string? Senha { get; set; }
        
        //data annotation "Aqui vai o nome da tabela que "
        [ForeignKey("Equipe")] //usando o data annotation para referenciar que é uma chave estrangeira 
        public int IdEquipe { get; set; }
        public Equipe? Equipe {get; set;}
    }
}