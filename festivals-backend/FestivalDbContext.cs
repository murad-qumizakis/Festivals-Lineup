using Microsoft.EntityFrameworkCore;


class FestivalDbContext : DbContext
{

    public FestivalDbContext(DbContextOptions<FestivalDbContext> options) : base(options)
    {
    }
    public DbSet<Festival> Festivals => Set<Festival>();
    public DbSet<Artist> Artists => Set<Artist>();

}