using Microondas.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Microondas.Controllers
{
    public class HomeController : Controller

    {
        static bool isPreAquecimento = false;

        private readonly ILogger<HomeController>? _logger;
        public IActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Personalizado()
        {
            return View();
        }

        public IActionResult IniciarAquecimento(int? segundos, int? potencia)
        {
            //Caso pot�ncia n�o tenha valor
            if (!potencia.HasValue)
            {
                potencia = 10;
                
            }

            //Mensagens de erro
            if (potencia < 0 || potencia > 10)
            {
                ViewBag.ErrorMessage = "Por favor, informe uma pot�ncia v�lida entre 0 e 10.";
                return View("Index");
            }

            if (segundos < 1 || segundos > 120)
            {
                ViewBag.ErrorMessage = "Por favor, informe um tempo v�lido entre 1 segundo e 2 minutos.";
                return View("Index");
            }

            //transforma segundos em minutos
            if (segundos > 60)
            {
                var minutos = TimeSpan.FromSeconds((double)segundos);
                ViewBag.Minutos = minutos;
            }

            ViewBag.Potencia = potencia;
            ViewBag.Segundos = segundos;


            return View("Index");
        }

        public IActionResult InfosPreAquecimento(string alimento)
        {
            MIcroondasModel model = new MIcroondasModel();

            switch (alimento.ToLower())
            {
                case "pipoca":
                    model.Nome = "Pipoca";
                    model.Alimento = "Pipoca";
                    model.TempoPreAquecimento = (int)3.0;  
                    model.PotenciaPreAquecimento = 7;
                    model.Instrucoes = "Observar o barulho de estouros do milho, caso houver um intervalo de mais de 10 segundos entre um estouro e outro, interrompa o aquecimento";
                    break;

                case "leite":
                    model.Nome = "Leite";
                    model.Alimento = "Leite";
                    model.TempoPreAquecimento = (int)5.0;  
                    model.PotenciaPreAquecimento = 5;
                    model.Instrucoes = "Cuidado com aquecimento de l�quidos, o choque t�rmico aliado ao movimento do recipiente pode \r\ncausar fervura imediata causando risco de queimaduras.";
                    break;

                case "carnes de boi":
                    model.Nome = "Carne de boi";
                    model.Alimento = "Carne em peda�o ou fatias";
                    model.TempoPreAquecimento = (int)14.0;
                    model.PotenciaPreAquecimento = 4;
                    model.Instrucoes = " Interrompa o processo na metade e vire o conte�do com a parte de baixo para cima para o \r\ndescongelamento uniforme.";

                    break;

                case "frango":
                    model.Nome = "Frango";
                    model.Alimento = "Frango (qualquer corte)";
                    model.TempoPreAquecimento = (int)8.0; 
                    model.PotenciaPreAquecimento = 7;
                    model.Instrucoes = "Interrompa o processo na metade e vire o conte�do com a parte de baixo para cima para o \r\ndescongelamento uniforme.";
                    break;

                case "feij�o":
                    model.Nome = "Feij�o";
                    model.Alimento = "Feij�o congelado";
                    model.TempoPreAquecimento = (int)8.0;
                    model.PotenciaPreAquecimento = 9;
                    model.Instrucoes = "Deixe o recipiente destampado e em casos de pl�stico, cuidado ao retirar o recipiente pois o mesmo \r\npode perder resist�ncia em altas temperaturas.\r\n";
                    break;
                default:
                    break;

            }
            ViewBag.Segundos = model.TempoPreAquecimento * 60;
            ViewBag.Potencia = model.PotenciaPreAquecimento;
            ViewBag.Instrucoes = model.Instrucoes;


            return View("Index", model);
        }

        public IActionResult StartRapidoBotao(int segundos = 30, int potencia = 10)
        {
            {
                //adere os valores para caso o usu�rio deseje o bot�o r�pido
                ViewBag.Potencia = potencia;
                ViewBag.Segundos = segundos;
            }
            return View("Index");
        }

        // Vari�vel de inst�ncia para o Timer


        public IActionResult Aquecimento(int segundos, int potencia)
        {
            var resultados = new List<string>();
            for (int i = 1; i <= segundos; i++)
            {
                for (int j = 1; j <= potencia; j++)
                {
                    resultados.Add($"Segundo {i}, Pot�ncia {j}");
                }
            }
            ViewBag.Resultados = resultados;
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
