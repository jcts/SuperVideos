using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperVideos.SharedKernel.Contexts;

namespace SuperVideos.WebApi
{
    public partial class Startup
    {
        public void AddContexts()
        {
            _ = _services.AddDbContext<MovieContext>(options => options.UseSqlite(Configuration.GetConnectionString("SandBox")));
        }
    }
}