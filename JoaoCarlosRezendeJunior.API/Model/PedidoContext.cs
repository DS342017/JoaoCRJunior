using Microsoft.EntityFrameworkCore;

namespace JoaoCarlosRezendeJunior.API.Model
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }

        public PedidoContext()
        {
        }

        public PedidoContext(DbContextOptions<PedidoContext> options)
            :base(options)
        {
        }
    }
}
