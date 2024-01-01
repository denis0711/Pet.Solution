using Microsoft.EntityFrameworkCore;


namespace Pet.Repository.Banco;

public class MeuBancoContext : DbContext
{
    public MeuBancoContext(DbContextOptions<MeuBancoContext> options) : base(options) {  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuBancoContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    

    public DbSet<Pet.Domain.Models.Pet> Pets { get; set; }
}
