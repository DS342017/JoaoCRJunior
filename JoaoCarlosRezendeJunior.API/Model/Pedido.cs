using System;
using System.ComponentModel.DataAnnotations;

namespace JoaoCarlosRezendeJunior.API.Model
{
    public class Pedido
    {
        public Pedido()
        {
        }

        [Key]
        public int IdPedido { get; set; }
        public string NomeMedicamento { get; set; }
        public int QtdeMedicamento { get; set; }
        public DateTime DataEntrega { get; set; }
        public int CodCliente { get; set; }
    }
}
