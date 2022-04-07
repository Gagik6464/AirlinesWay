using Microsoft.EntityFrameworkCore;

namespace AirlinesWay.Domain.DbContext;

public class AirlinesWayDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AirlinesWayDbContext()
    {
        
    }
    
    public AirlinesWayDbContext(DbContextOptions<AirlinesWayDbContext> options) : base(options)
    {
    }
    
    public DbSet<AirCompany> AirCompanies { get; set; }
    public DbSet<Airline> Airlines { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Flight> Flights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Airline)
            .WithMany(x => x.Flights)
            .HasForeignKey(x => x.AirlineId)
            .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Airline>(entity =>
        {
            entity.HasKey(x => x.Id);
            
            entity.HasOne(x => x.StartedCity)
                .WithMany(x => x.Airlines)
                .HasForeignKey(x => x.StartedCityId)
                .OnDelete(DeleteBehavior.NoAction);
                
            entity.HasOne(x => x.IntermediateCity)
                .WithMany(x => x.Airlines)
                .HasForeignKey(x => x.IntermediateCityId)
                .OnDelete(DeleteBehavior.NoAction);
            
            entity.HasOne(x => x.FinishedCity)
                .WithMany(x => x.Airlines)
                .HasForeignKey(x => x.FinishedCityId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(x => x.Id);
        });


        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasOne(x => x.Country)
            .WithMany(x => x.Cities)
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
        });
            

        modelBuilder.Entity<AirCompany>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.HasMany(x => x.Airlines)
            .WithMany(y => y.AirCompanies);
        });
            
    }
}