using System.ComponentModel.DataAnnotations;

namespace Projeto_Gamer_MVC.Models
{
    public class Equipe //cada classe vira uma tabela no banco de dados
    {
        [Key]  //Data annotation - IdEquipe
        public int IdEquipe { get; set; }
        public string? Nome { get; set; }
        public string? Imagem { get; set; }

        //referenciar a classe Equipe com a classe Jogador
        //Usado quando eu tenho a chave primária e uma chave secundária em outro lugar
        //se nesse outro lugar tivesse uma chave primária, eu colocaria o collection lá!

        public ICollection<Jogador>? Jogador {get; set;}

    }
}