using System;
using System.ComponentModel.DataAnnotations;

namespace JoaoCarlosRezendeJunior.MVC.Models
{
    public class PedidoViewModel
    {
        [Key]
        public int IdPedido { get; set; }
        [Display(Name = "Medicamento")]
        [Required]
        public string NomeMedicamento { get; set; }
        [Display(Name = "Qtde. Medicamento")]
        [Required]
        public int QtdeMedicamento { get; set; }
        [Display(Name = "Data de entrega")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }
        [Display(Name = "Cliente")]
        [Required]
        public int CodCliente { get; set; }
    }
}
