using Microsoft.EntityFrameworkCore;

namespace asp_dotnet_webapp_MVC.Data{
    public class asp_dotnet_webapp_MVCContext : DbContext{
        public asp_dotnet_webapp_MVCContext(DbContextOptions<asp_dotnet_webapp_MVCContext> options) : base(options) {}

        public DbSet<asp_dotnet_webapp_MVC.Models.TvShow> TvShow {get;set;}
    }
}