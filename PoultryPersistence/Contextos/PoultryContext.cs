using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PoultryDomain;

namespace PoultryPersistence.Contextos
{
    public class PoultryContext : DbContext
    {
        public PoultryContext(DbContextOptions<PoultryContext> options) : base(options){}
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            //Cliente
            modelBuilder.Entity<Cliente>()
                        .Property(c => c.dtNascimento)
                        .HasColumnType("Date");
            modelBuilder.Entity<Cliente>()
                        .Property(c => c.cpf)
                        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);;
            modelBuilder.Entity<Cliente>()
                        .HasMany(c => c.Endereco)
                        .WithOne(e => e.Cliente)
                        .OnDelete(DeleteBehavior.ClientCascade);

            //Pedido
            modelBuilder.Entity<Pedido>()
                        .Property(p => p.valorTotal)
                        .HasPrecision(18, 2);
            
            //Produto
            modelBuilder.Entity<Produto>()
                        .Property(p => p.valor)
                        .HasPrecision(18, 2);
            
            //ItemPedido
            modelBuilder.Entity<ItemPedido>()
                        .HasOne(ip => ip.Produto)
                        .WithMany(pe => pe.ItemPedido)
                        .HasForeignKey(ip => ip.ProdutoId);
            modelBuilder.Entity<ItemPedido>()
                        .HasOne(ip => ip.Produto)
                        .WithMany(pr => pr.ItemPedido)
                        .HasForeignKey(pr => pr.ProdutoId);
            modelBuilder.Entity<ItemPedido>()
                        .Property(ip => ip.valorUnitario)
                        .HasPrecision(18, 2);
        }

    }
}