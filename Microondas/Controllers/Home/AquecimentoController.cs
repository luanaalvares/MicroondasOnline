using AquecimentoPersonalisado.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AquecimentoPersonalisado.Controllers
{
    public class AquecimentoController : Controller
    {
        public IActionResult Index()
        {
            // Carregar dados do arquivo JSON
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "AquecimentoPersonalisado.json");
            if (System.IO.File.Exists(filePath))
            {
                string json = System.IO.File.ReadAllText(filePath);
                var model = JsonSerializer.Deserialize<PersonalisadoModel>(json);
                ViewBag.Model = model;
            }

            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult AdicionarJson(PersonalisadoModel model)
        {
            string json = JsonSerializer.Serialize(model);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "AquecimentoPersonalisado.json");

            try
            {
                System.IO.File.WriteAllText(filePath, json);
                ViewBag.Message = "Dados salvos com sucesso!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Erro ao salvar dados: {ex.Message}";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Personalizado(string NomePrograma, string NomeAlimento, int Potencia, int Segundos, string Caractere, string Instrucoes)
        {
            PersonalisadoModel model = new PersonalisadoModel
            {
                NomePrograma = NomePrograma,
                NomeAlimento = NomeAlimento,
                Potencia = Potencia,
                Segundos = Segundos,
                Caractere = Caractere,
                Instrucoes = Instrucoes
            };

            return AdicionarJson(model);
        }
    }
}
