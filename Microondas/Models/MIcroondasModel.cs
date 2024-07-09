namespace Microondas.Models
{
    public class MIcroondasModel
    {
        public int Tempo { get; set; }
        public int? Potencia { get; set; }

        public int? Segundos { get; set; }

        public double Minutos { get; set; }

        public int SegundosDecorridos { get; set; }
        public int SegundosDefinidos { get; set; }

        public string? Nome { get; set; }
        public string? Alimento { get; set; }

        public double TempoPreAquecimento { get; set; }

        public int PotenciaPreAquecimento { get; set; }

        public string? StringAquecimento { get; set; }
        public string? Instrucoes { get; set; }

        public int IsPreAquecimento { get; set; }
    }
}
