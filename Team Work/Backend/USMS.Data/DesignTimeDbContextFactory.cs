using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace USMS.Data;

// Lets "Add-Migration" / "dotnet ef" run on this project alone.
// Used only at design time; the API will register the context with its own connection string.
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UsmsDbContext>
{
    public UsmsDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<UsmsDbContext>()
            .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=USMS;Trusted_Connection=True;TrustServerCertificate=True")
            .Options;

        return new UsmsDbContext(options);
    }
}
