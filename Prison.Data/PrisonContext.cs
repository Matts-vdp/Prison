using Microsoft.EntityFrameworkCore;
using Prison.Data.Extensions;
using Prison.Models.Entities;

namespace Prison.Data;

public class PrisonContext : DbContext
{
    public PrisonContext(DbContextOptions<PrisonContext> dbContextOptions):base(dbContextOptions)
    {
        
    }

    public override int SaveChanges()
    {
        this.AddAuditInfo();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        this.AddAuditInfo();
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<PrisonBuilding> Prisons { get; set; } = null!;
    public DbSet<Cell> Cells { get; set; } = null!;
    public DbSet<Prisoner> Prisoners { get; set; } = null!;
}