using Microsoft.AspNetCore.Mvc;
using Projeto_Gamer_MVC.Infra;
using Projeto_Gamer_MVC.Models;

namespace Projeto_Gamer_MVC.Controllers
{
    [Route("[controller]")]
    public class JogadorController : Controller
    {
        private readonly ILogger<JogadorController> _logger;

        public JogadorController(ILogger<JogadorController> logger)
        {
            _logger = logger;
        }

        Context conexaoBanco = new Context();

        [Route("Listar")]
        public IActionResult Index()
        {

            ViewBag.Login = HttpContext.Session.GetString("UserName");

            ViewBag.Jogador = conexaoBanco.Jogador.ToList();
            ViewBag.Equipe = conexaoBanco.Equipe.ToList();
            return View();
        }

        //criando método cadastrar
        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador novoJogador = new Jogador();

            //atribuição de valores recebidos do forms
            novoJogador.Nome = form["Nome"].ToString();

            novoJogador.Email = form["Email"].ToString();

            novoJogador.Senha = form["Senha"].ToString();

            novoJogador.IdEquipe = int.Parse(form["IdEquipe"]);

            conexaoBanco.Jogador.Add(novoJogador);

            conexaoBanco.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id)
        {
            Jogador jogadorEncontrado = conexaoBanco.Jogador.FirstOrDefault(x => x.IdJogador == id)!;

            conexaoBanco.Remove(jogadorEncontrado);

            conexaoBanco.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }

        [Route("Editar/{id}")]
        public IActionResult Editar(int id)
        {

            ViewBag.Login = HttpContext.Session.GetString("UserName");

            Jogador jogadorEditar = conexaoBanco.Jogador.First(x => x.IdJogador == id)!;

            // ViewBag.Equipe = conexaoBanco.Equipe.ToList();
            ViewBag.Jogador = jogadorEditar;

            ViewBag.Equipe = conexaoBanco.Equipe.ToList();

            return View("Editar");
        }

        [Route("Atualizar")]
        public IActionResult Atualizar(IFormCollection form)
        {
            Jogador atualizarJogador = new Jogador();

            atualizarJogador.IdJogador = int.Parse(form["IdJogador"].ToString());

            atualizarJogador.Nome = form["Nome"].ToString();

            atualizarJogador.Email = form["Email"].ToString();

            atualizarJogador.Senha = form["Senha"].ToString();

            atualizarJogador.IdEquipe = int.Parse(form["IdEquipe"]);

            Jogador jogadorEncontrado = conexaoBanco.Jogador.First(x => x.IdJogador == atualizarJogador.IdJogador);

            jogadorEncontrado.Nome = atualizarJogador.Nome;
            jogadorEncontrado.Email = atualizarJogador.Email;
            jogadorEncontrado.Senha = atualizarJogador.Senha;
            jogadorEncontrado.IdEquipe = atualizarJogador.IdEquipe;

            conexaoBanco.Jogador.Update(jogadorEncontrado);

            conexaoBanco.SaveChanges();

            return LocalRedirect("~/Jogador/Listar");
        }
        // public IActionResult Atualizar (IFormCollection)

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}