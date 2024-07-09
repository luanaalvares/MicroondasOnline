namespace AquecimentoPersonalisado.Models
{
    public class PersonalisadoModel
    {
        public required string NomePrograma { get; set; }
        public required string NomeAlimento { get; set; }
        public required int Potencia { get; set; }
        public required int Segundos { get; set; }
        public required string Caractere { get; set; }
        public string? Instrucoes { get; set; }
    }

}