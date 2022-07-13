using Microsoft.EntityFrameworkCore;
using SubbyApi.DataLayer.MySQL.EFCore.DataModels;

namespace SubbyApi.DataLayer.MySQL.EFCore.Data
{
  public class SubbyContext : DbContext
  {
    public DbSet<SiteSettingsDataModel> SiteSettings { get; set; }

    public SubbyContext(DbContextOptions<SubbyContext> options) : base(options)
    {

    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<SiteSettingsDataModel>().HasKey(x => x.Id);
      
      base.OnModelCreating(modelBuilder);
    }
  }
}
