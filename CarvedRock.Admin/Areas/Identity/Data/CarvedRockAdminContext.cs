using CarvedRock.Admin.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarvedRock.Admin.Data;

public class CarvedRockAdminContext : IdentityDbContext<CarvedRockAdminUser>
{
    public string DbPath { get; set; }

    public CarvedRockAdminContext(IConfiguration config)
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DbPath = Path.Join(path, config.GetConnectionString("UserDbFilename"));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
