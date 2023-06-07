using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Gamer_MVC.Infra;
using Projeto_Gamer_MVC.Models;

namespace Projeto_Gamer_MVC.Controllers
{
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [TempData]
        public string message {get; set;}

        Context conexaoBancoLogin = new Context();

        [Route("Login")]
        public IActionResult Index()
        {
           ViewBag.Login = HttpContext.Session.GetString("UserName");

            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            string email = form["Email"].ToString();
            string senha = form["Senha"].ToString();

            Jogador jogadorBuscado = conexaoBancoLogin.Jogador.FirstOrDefault(x => x.Email == email && x.Senha == senha)!;

            //fazendo a lógica implementando a sessão:

            if (jogadorBuscado != null)
            {
                HttpContext.Session.SetString("UserName", jogadorBuscado.Nome!);
                return LocalRedirect("~/");
            }

            message = "Email ou Senha Incorretos";

            return LocalRedirect("~/Login/Login");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}