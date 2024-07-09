using AquecimentoPersonalisado.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace AquecimentoPersonalisado.Controllers
{
    public class AquecimentoController : Controller
    {

        public IActionResult Aquecimento()
        {
         
            return View();
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

            return View();
        }
    

    [HttpGet]
        public void Personalizado(string NomePrograma, string NomeAlimento, int Potencia, int Segundos, string Caractere, string Instrucoes )
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

            AdicionarJson(model);
        }
    }
}
