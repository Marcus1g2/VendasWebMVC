using System.ComponentModel.DataAnnotations;
using VendasWebMvc.Models.Enums;

namespace VendasWebMvc.Models
{
    public class RegistroDeVenda
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyy}")]
        public DateTime Data { get; set; }
        [DisplayFormat(DataFormatString ="{0:F2}")]
        public double Montante { get; set; }
        public StatusVenda Status { get; set; }
        public Vendedor Vendedor { get; set; }
        public RegistroDeVenda() { }

        public RegistroDeVenda(int id, DateTime data, double montante, StatusVenda status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            Montante = montante;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
