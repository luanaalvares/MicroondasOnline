using System.ComponentModel.DataAnnotations;

namespace Microondas.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        [Range(1, 120, ErrorMessage = "Por favor, informe um tempo válido entre 1 segundo e 2 minutos.")]
        public int Segundos { get; set; }

        [Range(0, 10, ErrorMessage = "Por favor, informe uma potência válida entre 0 e 10.")]
        public int? Potencia { get; set; }
    }


}
