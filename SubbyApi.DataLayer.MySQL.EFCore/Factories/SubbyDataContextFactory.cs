using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SubbyApi.DataLayer.MySQL.EFCore.Data;

namespace SubbyApi.DataLayer.MySQL.EFCore.Factories
{
  public class SubbyDataContextFactory : IDesignTimeDbContextFactory<SubbyContext>
  {
    public SubbyContext CreateDbContext(string[] args)
    {
      var connectionString = Environment.GetEnvironmentVariable("SUBBY_MYSQL_CONN_STR");
      
      var optionsBuilder = new DbContextOptionsBuilder<SubbyContext>();
      optionsBuilder.UseMySql("Server=localhost; Port=3307; Uid=root; Pwd=secret; database=usubindb;", 
        new MySqlServerVersion(new Version(5,7,32)),
        options =>
        { 
          options.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
        });

      return new SubbyContext(optionsBuilder.Options);
    }
  }
}
