using System.ComponentModel.DataAnnotations;
namespace MvcDemo.Models
{
    public class ContaDeLuz
    {
        public int Id { get; set; }
        [Required]
        public string DataDeLeitura { get; set; }
        [Required]
        public int NumLeitura { get; set; }
        [Required]
        public int KwGasto { get; set; }
        [Required]
        public float ValorPagar { get; set; }
        [Required]
        public string DataDoPagamento { get; set; }
        [Required]
        public float MediaDeConsumo { get; set; }
        
    }
}