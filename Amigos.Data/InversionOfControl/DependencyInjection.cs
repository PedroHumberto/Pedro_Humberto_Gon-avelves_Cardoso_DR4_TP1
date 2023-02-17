using Amigos.Application.Interfaces;
using Amigos.Data.Data;
using Amigos.Data.Repository;
using Amigos.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amigos.Data.InversionOfControl
{
    public class DependencyInjection
    {
        public static void Inject(IServiceCollection services, ConfigurationManager configuration)
        {
            //DbContext
            services.AddDbContext<FriendsDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DbConnectionString")));

            //Interfaces Injections
            services.AddScoped<IFriendRepository, FriendRepository>();
            services.AddScoped<IFriendService, FriendService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            

            


        }
    }
}
